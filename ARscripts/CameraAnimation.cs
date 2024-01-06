using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public float positionFloat;
    public float rotationFloat;
    public float force;
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        cam.DOShakePosition(positionFloat);
        cam.DOShakeRotation(rotationFloat,force);
    }

    
}
