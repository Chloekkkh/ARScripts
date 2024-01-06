using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwipManu : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform levelList;

    public HorizontalLayoutGroup HLG;
    public TMP_Text levelNum;

    public int currentLevel;
    public bool isSnapped;
    [SerializeField] private float distance;

    LevelSelect level;

    private void Start()
    {
        isSnapped = false;

        //解锁时对齐level；
        //currentLevel = level.unLockedLevel;
        //Vector3 snappedPosition = new Vector3(0 - (currentLevel * (levelList.rect.width + HLG.spacing)), contentPanel.localPosition.y, contentPanel.localPosition.z);
        //contentPanel.localPosition = Vector3.Lerp(contentPanel.localPosition, snappedPosition, 0.1f);

    }


    private void Update()
    {
        currentLevel = Mathf.RoundToInt(0 - contentPanel.localPosition.x / (levelList.rect.width + HLG.spacing));

        Debug.Log(currentLevel);

        Vector3 snappedPosition = new Vector3(0 - (currentLevel * (levelList.rect.width + HLG.spacing)), contentPanel.localPosition.y, contentPanel.localPosition.z);

        //Debug.Log(Vector3.Distance(contentPanel.GetChild(0).localPosition, snappedPosition));

        if (scrollRect.velocity.magnitude < 200 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;

            contentPanel.localPosition = Vector3.Lerp(contentPanel.localPosition, snappedPosition, 0.1f);

            if (contentPanel.localPosition == snappedPosition)
            {
                isSnapped = true;
                //contentPanel.GetChild(currentLevel).localScale = Vector3.Lerp(contentPanel.GetChild(currentLevel).localScale, contentPanel.GetChild(currentLevel).localScale * 2, 0.1f);
            }
            //contentPanel.GetChild(currentLevel).localScale = Vector3.Lerp(contentPanel.localScale, new Vector3(1, 1, 1), 0.1f);
        }

        if (scrollRect.velocity.magnitude > 200)
        {
            isSnapped = false;

        }
    }

}
