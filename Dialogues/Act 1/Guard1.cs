using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard1 : MonoBehaviour
{
    public Transform iniGuardPos, finalGuardPos, target, target2;

    public float speed = 4;
    public float elapsedTime, elapsedTime2;
    public bool movement1, movement2;
    public SpriteRenderer sr;


    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        target = finalGuardPos;
        target2 = finalGuardPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (King_Prince.guardsMovement == true)
        {
            movement1 = true;
            if(movement1 == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= 2)
                {
                    sr.flipX = true;
                    target = iniGuardPos;
                }
                if (transform.position == iniGuardPos.position)
                {
                    sr.flipX = false;
                    King_Prince.guardsMovement = false;
                    King_Prince.startCoroutine2 = true;
                    movement1 = false;
                }
            }

        }

        if (King_Prince.guardsMovement2 == true)
        {
            movement2 = true;
            if (movement2 == true)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
                elapsedTime2 += Time.deltaTime;
                if (elapsedTime2 >= 2)
                {
                    sr.flipX = true;
                    target2 = iniGuardPos;
                }
                if (transform.position == iniGuardPos.position)
                {
                    sr.flipX = false;
                    King_Prince.guardsMovement2 = false;
                    King_Prince.startCoroutine3 = true;
                    movement2 = false;
                }
            }
        }
    }
}
