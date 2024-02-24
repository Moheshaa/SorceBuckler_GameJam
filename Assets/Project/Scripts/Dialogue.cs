using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using static Unity.VisualScripting.Metadata;

[System.Serializable]
public class Dialogue
{
    public int id;
    public string dialogue;
    public string name;

    [TextArea(3, 10)]
    public Dialogue []sentences;
    public Dialogue(int n, string name, string dialogue, int id)
    {
        sentences = new Dialogue[n];
        this.name = name;
        this.dialogue = dialogue;
        this.id = id;
    }

}
