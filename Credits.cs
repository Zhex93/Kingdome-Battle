using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public float elapsedTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 10)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Menu");
        }
    }
}
