using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    private void Update()
    {
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Limits"))
        {
            Destroy(this.gameObject);
        }
    }
}
