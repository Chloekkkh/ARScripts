using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 旋转速度，单位是度每秒
    public Vector3 direction;

    void Update()
    {
        // 计算旋转角度
        float rotationAmount = rotationSpeed * Time.deltaTime;

        transform.Rotate(direction, rotationAmount);
    }
}
