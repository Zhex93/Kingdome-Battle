using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince1 : MonoBehaviour
{
    public Transform finalPos, finalPos2, target;
    public SpriteRenderer sr;
    public float speed;
    public static bool princePos = false;
    public CircleCollider2D cc;

    private void Start()
    {
        speed = 3;
        sr = gameObject.GetComponent<SpriteRenderer>();
        cc = gameObject.GetComponent<CircleCollider2D>();
        sr.flipX = true;
        target = finalPos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        if(King_Prince.princeMovement == true)
        {
            sr.flipX = false;
            target = finalPos2;
            King_Prince.startCoroutine4 = true;
            King_Prince.princeMovement = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Posicion"))
        {
            princePos = true;
            cc.enabled = false;
        }
    }
}
