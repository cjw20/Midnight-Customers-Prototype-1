﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkExample : MonoBehaviour
{
    public TextAsset inkJSONAsset;
    private Story story;
    public Button buttonPrefab;
    public Canvas canvas;

    public GameObject textWindow; 
    
    // Start is called before the first frame update
    void Start()
    {
       

    }

    public void SetDialogue(TextAsset dialogue)
    {
        inkJSONAsset = dialogue;
        // Load the next story block
        story = new Story(inkJSONAsset.text);


        textWindow.SetActive(true);
        // Start the refresh cycle
        refresh();
    }

    // Refresh the UI elements
    //  – Clear any current elements
    //  – Show any text chunks
    //  – Iterate through any choices and create listeners on them
    void refresh()
    {
        // Clear the UI
        clearUI();

        
        // Create a new GameObject
        GameObject newGameObject = new GameObject("TextChunk");
        // Set its transform to the Canvas (this)
        newGameObject.transform.SetParent(this.transform, false);

        // Add a new Text component to the new GameObject
        Text newTextObject = newGameObject.AddComponent<Text>();
        // Set the fontSize larger
        newTextObject.fontSize = 24;
        // Set the text from new story block
        newTextObject.text = getNextStoryBlock();
        // Load Arial from the built-in resources
        newTextObject.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        int choiceNumber = 0; //number of choices for current dialogue
        foreach (Choice choice in story.currentChoices)
        {
            choiceNumber++;
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(this.transform, false);

            // Gets the text from the button prefab
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            // Set listener
            choiceButton.onClick.AddListener(delegate {
                OnClickChoiceButton(choice);
            });

        }
        if(choiceNumber == 0)
        {
            StartCoroutine("EndDialogue");
        }
        //if no choices/story over next/end button goes here
    }
    IEnumerator EndDialogue()
    {
        yield return new WaitForSeconds(2f); //waits for a few seconds before closing dialogue

        //get changes to game variables here
        clearUI();
        textWindow.SetActive(false);
        //this.gameObject.SetActive(false);

        yield break;
    }
    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }

    // Clear out all of the UI, calling Destory() in reverse
    void clearUI()
    {
        //will need to make a way that only destroys parts of UI it needs to later (back panel)
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject); 
        }
        
    }


    // Load and potentially return the next story block
    string getNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;
    }
}
