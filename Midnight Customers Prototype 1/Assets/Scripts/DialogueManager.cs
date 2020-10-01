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

    Dialogue thisDialogue; //dialogue being used in conversation

    public GameObject optionsWindow;
    public Button[] optionButtons;

    GameControl gameControl;

    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        Time.timeScale = 0; //pauses updates for objects in scene

        thisDialogue = dialogue;

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
            if(thisDialogue.hasOptions == false)
            {
                EndDialogue();

                return;
            }

            else
            {
                OpenOptions();
                return;
            }
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    void OpenOptions()
    {
        int i = 0; //counter for loop below
        dialogueWindow.SetActive(false);
        optionsWindow.SetActive(true);
        foreach(Dialogue option in thisDialogue.options)
        {
            Text buttonText = optionButtons[i].transform.Find("Text").GetComponent<Text>();

            buttonText.text = option.optionName;
           
            //will need to add code to handle options in numbers other than 3

            optionButtons[i].onClick.AddListener(delegate { OnOptionSelect(option); });
            i++;
        }
    }

    public void OnOptionSelect(Dialogue dialogue)
    {
        optionsWindow.SetActive(false);
        StartDialogue(dialogue);
       
    }

    void EndDialogue()
    {
        dialogueWindow.SetActive(false);
        gameControl = GameObject.Find("Game Control").GetComponent<GameControl>();
        gameControl.SetDialougeResult(thisDialogue.conversationResult);
        Time.timeScale = 1f;

    }
}
