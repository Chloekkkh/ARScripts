using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAnimation : MonoBehaviour
{
    public float amplitude = 0.5f;    // 浮动的幅度
    public float frequency = 1f;      // 浮动的频率

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // 初始位置
    }

    void Update()
    {
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;//Time.time表示从游戏开始到当前帧的时间

        transform.position = tempPos;
    }
}
