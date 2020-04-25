using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public string scenename = "samplescene";
    public string scenename1 = "samplescene";
    public string scenename2 = "samplescene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //중복되는 로드씬 수정할 것
    public void LoadScene()
    {
        SceneManager.LoadScene(scenename);
    }

    public void LoadAlbum()
    {
        SceneManager.LoadScene(scenename1);
    }
    public void LoadOption()
    {
        SceneManager.LoadScene(scenename2);
    }
    
    public void BtnExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
