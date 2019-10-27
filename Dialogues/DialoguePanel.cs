using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public static DialoguePanel Instance { get; private set; }
    public Text textComponent;

    void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void ShowText(string text)
    {
        textComponent.text = text;
        this.gameObject.SetActive(true);
    }

    public bool IsShowing()
    {
        return this.gameObject.activeSelf;
    }

    public void CloseDialogue()
    {
        this.gameObject.SetActive(false);
    }
}
