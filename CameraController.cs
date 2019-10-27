using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public static float limitRight, limitLeft, limitDown, limitUp;

    void FixedUpdate()
    {
        transform.position = new Vector3(UIManager.Instance.newPlayer.transform.position.x, UIManager.Instance.newPlayer.transform.position.y, -0.3f);

        if (transform.position.x >= limitRight)
        {
            transform.position = new Vector3(limitRight, UIManager.Instance.newPlayer.transform.position.y, -0.3f);
            if (transform.position.y >= limitUp)
            {
                transform.position = new Vector3(limitRight, limitUp, -0.3f);
            }
            else if (transform.position.y <= limitDown)
            {
                transform.position = new Vector3(limitRight, limitDown, -0.3f);
            }
        }
        if (transform.position.x <= limitLeft)
        {
            transform.position = new Vector3(limitLeft, UIManager.Instance.newPlayer.transform.position.y, -0.3f);
            if (transform.position.y >= limitUp)
            {
                transform.position = new Vector3(limitLeft, limitUp, -0.3f);
            }
            else if (transform.position.y <= limitDown)
            {
                transform.position = new Vector3(limitLeft, limitDown, -0.3f);
            }
        }
        if (transform.position.y >= limitUp)
        {
            transform.position = new Vector3(UIManager.Instance.newPlayer.transform.position.x, limitUp, -0.3f);
            if (transform.position.x >= limitRight)
            {
                transform.position = new Vector3(limitRight, limitUp, -0.3f);
            }
            else if (transform.position.x <= limitLeft)
            {
                transform.position = new Vector3(limitLeft, limitUp, -0.3f);
            }
        }
        if (transform.position.y <= limitDown)
        {
            transform.position = new Vector3(UIManager.Instance.newPlayer.transform.position.x, limitDown, -0.3f);
            if (transform.position.x >= limitRight)
            {
                transform.position = new Vector3(limitRight, limitDown, -0.3f);
            }
            else if (transform.position.x <= limitLeft)
            {
                transform.position = new Vector3(limitLeft, limitDown, -0.3f);
            }
        }
    }
}
