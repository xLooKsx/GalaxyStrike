using System;
using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] String[] lines;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;


    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = lines[currentLine];
    }
}
