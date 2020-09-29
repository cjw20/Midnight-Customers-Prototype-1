using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string optionName; //name of option that starts this dialogue
    public string nameText; //name of speaker

    [TextArea(3, 10)]
    public string[] sentences;

    public Dialogue[] options;
}
