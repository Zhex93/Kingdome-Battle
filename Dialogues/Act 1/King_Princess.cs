using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King_Princess : MonoBehaviour
{
    public bool talking;
    public Text characterNameText;


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !talking)
        {
            StartCoroutine(TalkCoroutine());
            Princess1.Instance.movement = false;
            Princess1.Instance.anim.Play("Player_Idle");
        }
    }

    IEnumerator TalkCoroutine()
    {
        talking = true;
        characterNameText.text = ("Príncesa");
        DialoguePanel.Instance.ShowText("Buenos días, padre. ¿Me habéis hecho llamar?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Sí, hija mía. El reino está en crisis y debo encomendarte una peligrosa misión. Ha sucedido algo que jamás podríamos haber previsto…");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncesa");
        DialoguePanel.Instance.ShowText("¿El malvado Rey Demonio ha robado algo de nuestro reino y planea usarlo para destruirnos?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No… ¡Espera, si! ¡Es exáctamente eso! ¿Cómo lo has sabido?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncesa");
        DialoguePanel.Instance.ShowText("Por favor padre… ¿cómo no iba a saberlo? Es la situación más cliché del mundo. En todos los reinos vecinos ya ha ocurrido algo así. Me estaba preguntando cuándo nos tocaría a nosotros.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("¿En todos? ¿Incluso en el de esos idiotas del Reino Champiñón?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncesa");
        DialoguePanel.Instance.ShowText("Esos fueron los primeros.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("¿Y los de Hyrule?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncesa");
        DialoguePanel.Instance.ShowText("Nos llevan años de ventaja.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("El mundo se esta llendo a la mierda.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncesa");
        DialoguePanel.Instance.ShowText("En fin, me marcho de inmediato. Me muero de ganas de hacer algo interesante una vez.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Échale una mano a tu hermano si lo ves por ahí, hace días que le mandé a la misma misión y no tenemos noticias suyas...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }

        talking = false;
        Princess1.Instance.movement = true;

        UIManager.playerInstantiate = new Vector3(10, 3.8f, 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("First_City");
    }
}
