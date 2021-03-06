﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string optionName; //name of option that starts this dialogue
    public string nameText; //name of speaker
    public bool hasOptions; //if the dialogue should bring up options at end of dialogue.
    public string conversationResult; //result of conversation that will influence character behaviors etc

    [TextArea(3, 10)]
    public string[] sentences;

    public Dialogue[] options;
}
