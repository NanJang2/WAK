using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    //public DialogueAction action;

    public Dialogue dialogue;
    public int MyNum = 0;
    private void Awake()
    {
        LoadData();
    }

    public void LoadData()
    {
        string JsonString = File.ReadAllText(Application.dataPath + "./Dialogue_Text/DialogueData.json");
        
        Debug.Log(JsonString);

        JsonData LoadData = JsonMapper.ToObject(JsonString);

        //다이알로그 이름
        dialogue.Name = LoadData[MyNum]["Name"].ToString();
        //다이알로그 사이즈 정하는거
        dialogue.Sentences = new string[LoadData[MyNum]["Sentences"].Count];
        //다이알로그 대화
        for (int i = 0; i < LoadData[MyNum]["Sentences"].Count; i++)
            dialogue.Sentences[i] = LoadData[MyNum]["Sentences"][i].ToString();
        //다이알로그 끝났을때 변화
        dialogue.SceneChange_SceneName = LoadData[MyNum]["SceneChange_SceneName"].ToString();

        Debug.Log(LoadData[MyNum]["Sentences"].Count);
        //dialogue.Name = LoadData[MyNum]["Sentences"].Count;
        //    Debug.Log(LoadData[i]["Sentences"][0]);
        //}
        //dialogue = JsonUtility.FromJson<Dialogue>(JsonString);

        //Debug.Log(dialogue.name);
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
