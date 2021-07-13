using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject timePointPanel;
    public GameObject PausePanel;
    public GameObject catchPointText;
    public GameObject selectGreaterText;
    public GameObject topRectangle;
    public GameObject bottomRectangle;

    public Text topText;
    public Text bottomText;

    public int top, bottom;

    int gameCount = 0;
    int buttonValue;
    int greater;

    TimerManager timerManager;
    CircleManager circleManager;
    TrueFalseManager trueFalseManager;
    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
        circleManager = Object.FindObjectOfType<CircleManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
    }
    void Start()
    {
        UpdateScene();
    }

    void UpdateScene()
    {
        timePointPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        catchPointText.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        topRectangle.GetComponent<RectTransform>().DOMoveX(240, 0.7f).SetEase(Ease.OutBack);
        bottomRectangle.GetComponent<RectTransform>().DOMoveX(240, 0.7f).SetEase(Ease.OutBack);
        catchPointText.GetComponent<CanvasGroup>().DOFade(0, 1f);
        selectGreaterText.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    public void StartGame()
    {
        UpdateValues();
        timerManager.StartTimer();
    }
    public void UpdateValues()
    {
        int gameNumber;
        if (gameCount < 5)
        {
            gameNumber = 1;
        }
        else if (gameCount >= 5 && gameCount<10)
        {
            gameNumber = 2;
        }
        else if (gameCount>=10 && gameCount<15)
        {
            gameNumber = 3;
        }
        else if (gameCount>=15 && gameCount<20)
        {
            gameNumber = 4;
        }
        else if (gameCount>20 && gameCount<25)
        {
            gameNumber = 5;
        }
        else
        {
            gameNumber = Random.Range(1, 6);
        }
        

        if (gameNumber == 1)
        {
            top = Random.Range(1, 80);
            do
            {
                bottom = Random.Range(1, 80);
            } while (top == bottom);

            bottomText.text = bottom.ToString();
            topText.text = top.ToString();
        }
        else if (gameNumber == 2)
        {
            int x = Random.Range(10, 80);
            int y = Random.Range(10, 80);
            top = x + y;
            int z, t;
            do
            {
                z = Random.Range(10, 80);
                t = Random.Range(10, 80);
                bottom = z + t;
            } while (top == bottom);

            topText.text = x.ToString() + " + " + y.ToString();
            bottomText.text = z.ToString() + " + " + t.ToString();
        }
        else if (gameNumber == 3)
        {
            int x = Random.Range(10, 80);
            int y = Random.Range(1, x);
            top = x - y;
            int z, t;
            do
            {
                z = Random.Range(10, 80);
                t = Random.Range(1, z);
                bottom = z - t;
            } while (top == bottom);

            topText.text = x.ToString() + " - " + y.ToString();
            bottomText.text = z.ToString() + " - " + t.ToString();
        }
        else if (gameNumber == 4)
        {
            int x = Random.Range(1,15);
            int y = Random.Range(1,15);
            top = x * y;
            int z, t;
            do
            {
                z = Random.Range(1, 15);
                t = Random.Range(1, 15);
                bottom = z * t;
            } while (top == bottom);

            topText.text = x.ToString() + " x " + y.ToString();
            bottomText.text = z.ToString() + " x " + t.ToString();
        }
        else if (gameNumber == 5)
        {
            int x = Random.Range(2,10);
            top = Random.Range(2, 10);
            int y = x * top;
            int z, t;
            do
            {
                z = Random.Range(2, 10);
                bottom = Random.Range(2, 10);
                t = z * bottom;
            } while (top == bottom);

            topText.text = y.ToString() + " / " + x.ToString();
            bottomText.text = t.ToString() + " / " + z.ToString();
        }

        if (top < bottom)
        {
            greater = bottom;
        }
        else
        {
            greater = top;
        }
    }


    public void ButtonValue(int buttonNumber)
    {
        if (buttonNumber == 1)
        {
            buttonValue = top;
        }
        else if (buttonNumber == 2)
        {
            buttonValue = bottom;
        }

        if (buttonValue == greater)
        {
            circleManager.OpenCircleScale(gameCount % 5);
            gameCount++;
            trueFalseManager.OpenScale(true);
            UpdateValues();
        }
        else
        {
            trueFalseManager.OpenScale(false);
            gameCount -= (gameCount % 5 + 5);
            if (gameCount<0)
            {
                gameCount = 0;
            }
            circleManager.CloseCircleScale();
        }

    }

    public void click()
    {
        Debug.Log("click");
    }

    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
    }
}
