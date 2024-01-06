using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFadin : MonoBehaviour
{
    public Image fadeImage;
    public float fadeInTime = 3;
    public float fadeOutTIme = 3;

    void Start()
    {
        StartCoroutine(Fadein());
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

}
