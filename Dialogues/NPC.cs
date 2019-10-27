using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    bool talking;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !talking)
        {
            StartCoroutine(TalkCoroutine());
        }
    }

    IEnumerator TalkCoroutine()
    {
        talking = true;
        DialoguePanel.Instance.ShowText("¡Hola!");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        DialoguePanel.Instance.ShowText("¡Gilipollas!");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        OptionsPanel.Instance.ShowOptions("¡Gilipollas tú!", "Muchas gracias");
        while (OptionsPanel.Instance.IsShowing())
        {
            yield return null;
        }
        if (OptionsPanel.Instance.optionChosen == 0)
        {
            DialoguePanel.Instance.ShowText("¡Jo, tío!");
            while (DialoguePanel.Instance.IsShowing())
            {
                yield return null;
            }
        }
        else if (OptionsPanel.Instance.optionChosen == 1)
        {
            DialoguePanel.Instance.ShowText("De nada ;)");
            while (DialoguePanel.Instance.IsShowing())
            {
                yield return null;
            }
        }
        talking = false;
    }
}
