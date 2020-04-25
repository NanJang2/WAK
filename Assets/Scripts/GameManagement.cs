using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public GameObject pauseUI;
    public player_controller pc;
    private bool ispaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ispaused = !ispaused;
        }
        if (ispaused)
        {
            pauseUI.SetActive(true);
            pc.InputDisabled = true;
            Time.timeScale = 0f;
        }
        if (!ispaused)
        {
            pauseUI.SetActive(false);
            pc.InputDisabled = false;
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        ispaused = false;
    }
}
