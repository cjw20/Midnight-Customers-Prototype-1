using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueWindow;

    public GameObject[] dialogueOptions;

    public GameObject optionsWindow;

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        Time.timeScale = 0; //pauses updates for objects in scene

        dialogueOptions = dialogue.options;

        dialogueWindow.SetActive(true);

        nameText.text = dialogue.nameText;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if(dialogueOptions.Length == 0)
            {
                EndDialogue();

                return;
            }
            
            
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    void EndDialogue()
    {
        dialogueWindow.SetActive(false);

        Time.timeScale = 1f;

    }
}
