using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public static bool talking;
    public Text characterNameText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(TalkCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
