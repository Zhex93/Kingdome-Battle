using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King_Prince : MonoBehaviour
{
    bool talking;
    public Text characterNameText;
    public GameObject prince;
    public float elapsedTime;
    bool startCoroutine;
    public static bool guardsMovement = false;
    public static bool guardsMovement2 = false;
    public static bool princeMovement = false;
    public static bool startCoroutine2 = false;
    public static bool startCoroutine3 = false;
    public static bool startCoroutine4 = false;

    private void Update()
    {
        //Debug.Log(guardsMovement);
        if (Prince1.princePos == true)
        {
            elapsedTime += Time.deltaTime;
            startCoroutine = true;
            if (elapsedTime >= 0.05f)
            {
                Prince1.princePos = false;
                startCoroutine = false;
                elapsedTime = 0;
            }
        }

        if (startCoroutine2 == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 0.05f)
            {
                startCoroutine2 = false;
                elapsedTime = 0;
            }
        }

        if (startCoroutine3 == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 0.05f)
            {
                startCoroutine3 = false;
                elapsedTime = 0;
            }
        }

        if (startCoroutine4 == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 0.05f)
            {
                startCoroutine4 = false;
                elapsedTime = 0;
            }
        }

        if (startCoroutine == true && ! talking)
        {
            StartCoroutine(TalkCoroutine1());
        }

        if (startCoroutine2 == true && !talking)
        {
            StartCoroutine(TalkCoroutine2());
        }

        if (startCoroutine3 == true && !talking)
        {
            StartCoroutine(TalkCoroutine3());
        }

        if (startCoroutine4 == true && !talking)
        {
            StartCoroutine(TalkCoroutine4());
        }
    }

    IEnumerator TalkCoroutine1()
    {
        talking = true;
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("¿Por qué motivo me habéis hecho llamar tan temprano, padre?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Apenas he podido dormir 10 horas.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Verás hijo mío..");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("¿Sabes que no dormir lo suficiente es horrible para la piel?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Hijo...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Dime, ¿en qué reino se ha visto que el príncipe heredero tenga unas ojeras como las de un mapache?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Y eso por no hablar de que no he podido ni desayunar. Ya sabes el mal humor que tengo cuando no desayuno.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("¡Silencio! Cierra la boca y escúchame de una vez. Ha sucedido lo impensable…");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("¿Han logrado demostrar que la Tierra es redonda?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("¿El equipo de justas del reino ha pasado de cuartos?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("¿Mi hermana ha encontrado por fin un pretendiente?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("¿Al nuevo obispo del reino no le gustan los niños?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Bueno, tan impensable no será si nada de esto ha sucedido, padre.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Escucha, nuestro archienemigo, el Rey Demonio, se ha atrevido a…");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("...grabar un disco recopilatorio con los mayores éxitos de Alejandro Sanz.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("¡No!…¿¡Quieres dejar de interrumpirme de una maldita vez!? ¡Esto es muy serio! ¿Y qué narices es un “disco recopilatorio”?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Típico, mandarme callar porque no sabes lo que es algo. Eso es taaan de 1300…");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("¡Guardias! Amordazadlo hasta que termine de explicar la situación o no acabaremos hasta mañana.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }

        talking = false;
        guardsMovement = true;
        if (guardsMovement == true)
        {
            yield return null;
        }
    }

    IEnumerator TalkCoroutine2()
    {
        talking = true;

        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Mmmmmmpff mmmmmpppff");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Así está mejor. Como iba diciendo, ese maldito Rey Demonio se ha atrevido a robar un peligroso artefacto de nuestro tesoro.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Es tan poderoso que podría sumir a nuestro reino en el caos con solo intentar usarlo.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Por eso hijo, te encomiendo la misión de reunir un grupo de voluntarios e ir a recuperarlo.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Yo ya soy demasiado anciano para esas aventuras, y la verdad, no me apetece volver a enfrentarme al Rey Demonio en persona.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Mmmffp mpfff");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Ah, cierto, quitadle ya la mordaza.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }

        talking = false;
        guardsMovement2 = true;
        if (guardsMovement2 == true)
        {
            yield return null;
        }
    }

    IEnumerator TalkCoroutine3()
    {
        talking = true;

        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Maldita sea, padre. ¿Así tratas a tu propio hijo? Normal que escuche a la plebe decir esas cosas de ti cuando paseo por las calles.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("¿Qué cosas dice la plebe sobre mi?");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Nada, nada; eres un rey muuuuuuy querido.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("...en fin. No te demores más. Debes partir de inmediato para detener los planes del Rey Demonio.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Sabes, ayudaría bastante saber que es ese misterioso artefacto que ha robado del tesoro para saber qué es lo que tengo que recuperar.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Eso no puedo decírtelo. No puedo permitir que más gente conozca sobre este artefacto, ni siquiera a mis propios hijos.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No. Especialmente a mis propios hijos.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("...vaya. Eso ha sido muy misterioso...");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("En fin pues me marcho de inmediato a por ese Rey Demonio. ");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Príncipe");
        DialoguePanel.Instance.ShowText("Conseguir un equipo solo me hará perder tiempo y yo sólo me basto para darle caza.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }

        talking = false;
        princeMovement = true;
    }

    IEnumerator TalkCoroutine4()
    {
        talking = true;
        yield return new WaitForSeconds(0.8f);

        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("No, hijo. Es muy poderoso, busca aliados.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Guardia");
        DialoguePanel.Instance.ShowText("Es inútil magestad, ya está demasiado lejos como para que le escuche.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        characterNameText.text = ("Rey");
        DialoguePanel.Instance.ShowText("Maldita sea, solo espero que este idiota no lo empeore aún más.");
        while (DialoguePanel.Instance.IsShowing())
        {
            yield return null;
        }
        talking = false;

        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Act_1.2");
    }
}

