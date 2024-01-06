using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static LevelSelect instance;

    public Button[] levelSelectButtons;

    public Player player;



    public float fadeInTime = 3;
    public float fadeOutTIme = 3;

    public Image loadImage;

    private void Awake()
    {

        instance = this;
        
    }
    private void Start()
    {

        levelSelectButtons[0].onClick.AddListener(() => LoadLevel(1));
        levelSelectButtons[1].onClick.AddListener(() => LoadLevel(2));
        levelSelectButtons[2].onClick.AddListener(() => LoadLevel(3));


        for (int level = 0; level < 3; level++)
        {
            bool unlockStatus = PlayerPrefs.GetInt("Level" + (level).ToString(), 0) == 1 ? true : false;
            
            levelSelectButtons[level].interactable = unlockStatus;
            GameObject lockImage = levelSelectButtons[level ].transform.Find("lockimage").gameObject;
            //解锁
            //可以做个小动画
            lockImage.SetActive(!unlockStatus);
        }
    }

    public void LoadLevel(int levelNum)
    {
        StartCoroutine(LoadSceneAsyc(levelNum));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNum);
    }

    IEnumerator Fadein()
    {
        Color originalColor = loadImage.GetComponent<Image>().color;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInTime);
            loadImage.GetComponent<Image>().color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator LoadSceneAsyc(int levelNum)
    {
        Color originalColor = loadImage.color;
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            loadImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + levelNum);
    }

}
