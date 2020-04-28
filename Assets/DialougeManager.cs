using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialougeManager : MonoBehaviour
{
    static public DialougeManager instance;

    public GameObject DialoguePanel;
    public Text ChatName;
    public Text ChatText;
    public GameObject scanObject;
    public bool isAction = false;

    private Queue<string> sentences;

    private IEnumerator chatcoroutine;
    private string writerText;
    private string chattername;
    private string lastsentence;
    private bool ChatAnimPlaying = false;

    private Dialouge dialouge;
    //DialougeAction action;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sentences = new Queue<string>();
    }

    IEnumerator ChatAnim(string narrator, string narration)
    {
        ChatAnimPlaying = true;
        ChatName.text = narrator;
        writerText = "";
        for (int i = 0; i < narration.Length; i++)
        {
            writerText += narration[i];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }
        ChatAnimPlaying = false;
    }

    public void Action(GameObject scanObj)
    {
        if (ChatAnimPlaying)
        {
            StopCoroutine(chatcoroutine);
            if (ChatAnimPlaying)
                ChatAnimPlaying = false;
            ChatText.text = lastsentence;
        }
        else
        {
            if (!isAction)
            {
                isAction = true;
                scanObject = scanObj;
                chatcoroutine = ChatAnim("주인공", scanObject.name + "이다.");
                lastsentence = scanObject.name + "이다.";
                StartCoroutine(chatcoroutine);
            }
            else if (isAction)
            {
                isAction = false;
            }

            DialoguePanel.SetActive(isAction);
        }


    }



    public void StartDialouge(Dialouge dialouge_temp)
    {
        dialouge = dialouge_temp;
        //action = action_temp;
        //큐에 탑재
        //Debug.Log(dialouge.name);
        sentences.Clear();

        foreach (string sentence in dialouge.Sentences)
        {
            sentences.Enqueue(sentence);
        }
        chattername = dialouge.Name;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!isAction)
        {
            isAction = true;
            DialoguePanel.SetActive(isAction);
        }

        if (ChatAnimPlaying)
        {
            StopCoroutine(chatcoroutine);
            if (ChatAnimPlaying)
                ChatAnimPlaying = false;
            ChatText.text = lastsentence;
        }
        else
        {
            if (sentences.Count == 0)
            {

                EndDialogue(/*dialouge.action*/);
                return;
            }
            string sentence = sentences.Dequeue();
            lastsentence = sentence;
            chatcoroutine = ChatAnim(chattername, sentence);
            StartCoroutine(chatcoroutine);
        }
        //Debug.Log(sentence);
    }
    void EndDialogue(/*Action action*/)
    {

        //여기서 씬이 있다면 씬 체인지 (씬이름은 인스펙터에서 바꾸실 수 있습니다. Dialouge하위에 있습니다.)
        if (dialouge.SceneChange_SceneName != "")
            SceneManager.LoadScene(dialouge.SceneChange_SceneName);

        if (isAction)
        {
            isAction = false;
        }
        DialoguePanel.SetActive(isAction);
        //Debug.Log("End");
    }
}
