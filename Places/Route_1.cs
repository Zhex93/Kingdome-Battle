using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Route_1 : MonoBehaviour
{
    void Start()
    {
        CameraController.limitRight = -4.33f;
        CameraController.limitLeft = -21.65f;
        CameraController.limitUp = 11;
        CameraController.limitDown = -10;
    }
}
