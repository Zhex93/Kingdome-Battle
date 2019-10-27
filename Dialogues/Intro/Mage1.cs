using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage1 : MonoBehaviour
{
    public GameObject demon;
    public Transform finalPos, finalPos2;
    public SpriteRenderer sr;
    public float speed = 4;
    public static bool afterDemonConversation;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(afterDemonConversation == true)
        {
            sr.flipX = true;
            transform.position = Vector3.MoveTowards(this.transform.position, finalPos2.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(this.transform.position, finalPos.position, speed * Time.deltaTime);
        }

        if (transform.position == finalPos2.position)
        {
            afterDemonConversation = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Act_1.1");
        }
    }
}
