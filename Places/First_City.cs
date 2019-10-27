using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_City : MonoBehaviour
{
    private void Awake()
    {
    }

    void Start()
    {
        CameraController.limitRight = 8.5f;
        CameraController.limitLeft = -21.6f;
        CameraController.limitUp = 5;
        CameraController.limitDown = -10;
    }
}
