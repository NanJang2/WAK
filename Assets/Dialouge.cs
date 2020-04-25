using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge
{
    public string Name;
    [TextArea(3, 6)]
    //public List<string> Sentences = new List<string>();
    public string[] Sentences;

    public string SceneChange_SceneName = "";
    
    public Dialouge(string name, string[] sentences/*List<string> sentences*/)
    {
        Name = name;
        Sentences = sentences;
    }
}
