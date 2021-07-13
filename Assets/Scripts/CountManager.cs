using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountManager : MonoBehaviour
{
    public GameObject countBackImage;
    public Text countBackText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        StartCoroutine(CountBackRoutine());
    }

    public IEnumerator CountBackRoutine()
    {
        countBackText.text = "3";
        yield return new WaitForSeconds(0.5f);
        countBackImage.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        countBackImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        countBackText.text = "2";
        yield return new WaitForSeconds(0.5f);
        countBackImage.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        countBackImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        countBackText.text = "1";
        yield return new WaitForSeconds(0.5f);
        countBackImage.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        countBackImage.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        StopAllCoroutines();

        gameManager.StartGame();
        
    }
}
