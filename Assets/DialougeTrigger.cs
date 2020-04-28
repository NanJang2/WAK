using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class DialougeTrigger : MonoBehaviour
{
    //public DialougeAction action;

    public Dialouge dialouge;
    public int MyNum = 0;
    private void Awake()
    {
        LoadData();
    }

    public void LoadData()
    {
        string JsonString = File.ReadAllText(Application.dataPath + "./Dialouge_Text/DialougeData.json");
        
        Debug.Log(JsonString);

        JsonData LoadData = JsonMapper.ToObject(JsonString);

        //다이알로그 이름
        dialouge.Name = LoadData[MyNum]["Name"].ToString();
        //다이알로그 사이즈 정하는거
        dialouge.Sentences = new string[LoadData[MyNum]["Sentences"].Count];
        //다이알로그 대화
        for (int i = 0; i < LoadData[MyNum]["Sentences"].Count; i++)
            dialouge.Sentences[i] = LoadData[MyNum]["Sentences"][i].ToString();
        //다이알로그 끝났을때 변화
        dialouge.SceneChange_SceneName = LoadData[MyNum]["SceneChange_SceneName"].ToString();

        Debug.Log(LoadData[MyNum]["Sentences"].Count);
        //dialouge.Name = LoadData[MyNum]["Sentences"].Count;
        //    Debug.Log(LoadData[i]["Sentences"][0]);
        //}
        //dialouge = JsonUtility.FromJson<Dialouge>(JsonString);

        //Debug.Log(dialouge.name);
    }

    public void TriggerDialouge()
    {
        DialougeManager.instance.StartDialouge(dialouge);
        //FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
}
