using UnityEngine;
using TMPro;
using System.Collections;

public class TextAnimation : MonoBehaviour
{
    public static TextAnimation instance;

    public TMP_Text textMeshPro;

    //type
    public string fullText;
    public float typingSpeed = 0.05f;

    //fade in
    //fade out
    public float fadeInTime = 2.0f;
    public float displayTime = 2.0f;
    public float fadeOutTime = 2.0f;

    private void Start()
    {

        instance = this;
        //StartCoroutine(TypeText());
    }

    private void Update()
    {
        //如果脚下是A textMeshPro = Atest

    }

    public void Fadeinn()
    {
        StartCoroutine(FadeIn());
       
    }
    public void TypeInn()
    {
        StartCoroutine(TypeText());
        
    }

    IEnumerator FadeIn()
    {
        Color originalColor = textMeshPro.color;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 等待一段时间后开始渐出效果
        yield return new WaitForSeconds(displayTime);

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color originalColor = textMeshPro.color;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeOutTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 可以在这里执行其他操作，例如销毁对象或者禁用 TextMeshPro 组件
    }

    IEnumerator TypeText()
    {
        Color originalColor = textMeshPro.color;
        textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1);
        int currentCharacter = 0;
        textMeshPro.text = ""; // 清空文本

        while (currentCharacter < fullText.Length)
        {
            textMeshPro.text += fullText[currentCharacter];
            currentCharacter++;
            yield return new WaitForSeconds(typingSpeed);
        }

        // 等待一段时间后开始渐出效果
        yield return new WaitForSeconds(displayTime);
        StartCoroutine(FadeOut());
    }
}