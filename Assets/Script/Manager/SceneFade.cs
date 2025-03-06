using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Image fadeImage; 
    public float fadeDuration = 1f; 
    public static SceneFade Instance;

    public void Start()
    {
        Instance = this;
        FadeIn();
    }

    public void FadeToScene(string sceneName)
    {
        FadeOut(sceneName);
    }

    private void FadeIn()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(0, 0, 0, 1); 
        fadeImage.DOFade(0, fadeDuration).OnComplete(() => fadeImage.gameObject.SetActive(false));
    }

    private void FadeOut(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.DOFade(1, fadeDuration).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
