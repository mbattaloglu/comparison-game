using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timeText;
    
    int remaining = 90;


    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timeText.text = remaining.ToString();
            remaining--;

            if (remaining == 0)
            {
                break;
            }
        }
    }
}
