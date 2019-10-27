using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        CameraController.limitRight = 4.65f;
        CameraController.limitLeft = -4.65f;
        CameraController.limitUp = 13;
        CameraController.limitDown = 2;
    }

}
