using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
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

    private void Start()
    {
        sentences = new Queue<string>();
    }
    IEnumerator ChatAnim(string narrator, string narration)
    {
        ChatAnimPlaying = true;
        ChatName.text = narrator;
        writerText = "";
        for(int i = 0; i < narration.Length; i++)
        {
            writerText += narration[i];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.05f);
        }
        ChatAnimPlaying = false;
    }
    public void Action(GameObject scanObj)
    {
        if(ChatAnimPlaying)
        {
            StopCoroutine(chatcoroutine);
            if (ChatAnimPlaying)
                ChatAnimPlaying = false;
            ChatText.text = lastsentence;
        }
        else
        {
            if(!isAction)
            {
                isAction = true;
                scanObject = scanObj;
                chatcoroutine = ChatAnim("주인공", scanObject.name + "이다.");
                lastsentence = scanObject.name + "이다.";
                StartCoroutine(chatcoroutine);
            }
            else if(isAction)
            {
                isAction = false;
            }

            DialoguePanel.SetActive(isAction);
        }
        

    }
 
  

    public void StartDialouge(Dialouge dialouge)
    {
        //큐에 탑재
        //Debug.Log(dialouge.name);
        sentences.Clear();
        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        chattername = dialouge.name;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (!isAction)
        {
            isAction = true;
            DialoguePanel.SetActive(isAction);
        }
        
        if(ChatAnimPlaying)
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
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            lastsentence = sentence;
            chatcoroutine = ChatAnim(chattername, sentence);
            StartCoroutine(chatcoroutine);
        }
        
        
        
        //Debug.Log(sentence);
    }
    void EndDialogue()
    {
        if(isAction)
        {
            isAction = false;
        }
        DialoguePanel.SetActive(isAction);
        //Debug.Log("End");
    }
}
