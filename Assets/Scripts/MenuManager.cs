using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Transform head;
    public Transform buttonTransform;
    void Start()
    {
        head.transform.GetComponent<RectTransform>().DOLocalMoveY(0f, 1f).SetEase(Ease.InOutBack);
        buttonTransform.transform.GetComponent<RectTransform>().DOLocalMoveY(-200f, 1f).SetEase(Ease.InOutBack);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
