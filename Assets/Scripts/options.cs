using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    private bool isfullScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toFullscreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
            isfullScreen = true;
        }
            
        
    }
    public void toWindowed()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            isfullScreen = false;
        }
            
    }

    public void set720()
    {
        if (isfullScreen)
        {
            Screen.SetResolution(1280, 720, true);
        }
        else
        {
            Screen.SetResolution(1280, 720, false);
        }
    }
    public void set1080()
    {
        if (isfullScreen)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
        }

    }

}
