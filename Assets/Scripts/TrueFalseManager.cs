using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    public GameObject trueIcon;
    public GameObject falseIcon;

    private void Start()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void OpenScale(bool check)
    {
        if (check)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            Invoke("CloseScale", 0.5f);
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            Invoke("CloseScale", 0.5f);
        }
    }

    public void CloseScale()
    {

        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
