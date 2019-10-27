using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Vector2 mov;
    public float speed = 8;

    void Update()
    {
        transform.position += new Vector3(mov.x, mov.y, 0) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
