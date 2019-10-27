using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonKing1 : MonoBehaviour
{
    public GameObject mage;

    public static bool talking, startCoroutine;
    public float elapsedTime;
    public Text characterNameText;
    private Vector3 magePos;

    private void Start()
    {
        magePos = new Vector3(-5, 0, 0);
    }

    private void Update()
    {

        if(mage.transform.position == new Vector3(-5, 0, 0))
        {
            elapsedTime += Time.deltaTime;
            startCoroutine = true;
            if (elapsedTime >= 0.05)
            {
                startCoroutine = false;
                magePos = new Vector3(-10, 0, 0);
            }
        }

        if(startCoroutine == true)
        {
            StartCoroutine(TalkCoroutine());
        }
    }

    IEnumerator TalkCoroutine()
    {
        talking = true;
        characterNameText.text = ("Esbirro");
        DialoguePanel.Instance.ShowText("Mi señor, los preparativos han sido completados. Sus soldados están listos para ejecutar su plan cuando desee.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey Demonio");
        DialoguePanel.Instance.ShowText("Excelente… ¡Poneos en marcha de inmediato! Dentro de poco este reino será mío.!");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey Demonio");
        DialoguePanel.Instance.ShowText("Muahahahahahahahaha.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        talking = false;
        Mage1.afterDemonConversation = true;
    }
}
