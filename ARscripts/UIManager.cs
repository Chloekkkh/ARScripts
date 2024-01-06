using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private bool isLocked;
    public GameObject setPanel;

    public Image fadeImage;
    public float fadeInTime;
    public float fadeOutTIme;

    public Camera cam;
    public float shackFloat = 2f;
    public float shackForce = 3f;

    private void Start()
    {
        StartCoroutine(Fadein());
    }

    public void StartGame()
    {
        UnlockNextLevel();
        StartCoroutine(Fadeout());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SetButton()
    {
        setPanel.SetActive(true);
    }

    public void SetBackButton()
    {
        setPanel.SetActive(false);
    }

    public void Quit()
    {
        // 关闭游戏
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        // 在应用程序关闭时清除 PlayerPrefs 数据
        PlayerPrefs.DeleteAll();
    }

    void UnlockNextLevel()
    {
        int currentLevel = -1; // 当前关卡号，这里假设为第二关
        int nextLevel = currentLevel + 1; // 下一关

        // 将下一关的解锁状态设置为已解锁（状态值为1）
        PlayerPrefs.SetInt("Level" + nextLevel.ToString(), 1);
        PlayerPrefs.Save(); // 保存数据

        // 返回选关页面
        //SceneManager.LoadScene(1); // 实现此函数来加载选关页面
    }

    IEnumerator Fadein()
    {
        Color originalColor = fadeImage.color;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInTime);
            fadeImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator Fadeout()
    {
        Color originalColor = fadeImage.color;
        float elapsedTime = 0.0f;
        cam.DOShakeRotation(shackFloat, shackForce);
        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            fadeImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}
