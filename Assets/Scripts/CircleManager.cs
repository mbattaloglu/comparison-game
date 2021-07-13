using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleManager : MonoBehaviour
{
    public GameObject[] lightCircles;
    void Start()
    {
        CloseCircleScale();
    }

    public void CloseCircleScale()
    {
        foreach (GameObject circle in lightCircles)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    public void OpenCircleScale(int circleNumber)
    {
        lightCircles[circleNumber].GetComponent<RectTransform>().DOScale(1, 0.3f);
        if (circleNumber % 5 == 0)
        {
            CloseCircleScale();
        }
    }
}
