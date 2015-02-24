using UnityEngine;

public class PauseMenu : Navigation
{
    public Canvas PauseCanvas; //Our scene canvas 


    public void Start() 
    {
        Screen.lockCursor = true;
        Screen.showCursor = false;
    }

    public void Update()
    {
        // If the escape key is pressed then the following instruction is loaded
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas.enabled)
                Resume();
            else
                Pause();
        }
   	}

    public void Pause()
    {
        PauseCanvas.enabled = true;
        Time.timeScale = 0; // FIXME should pause game
        Screen.lockCursor = false;
        Screen.showCursor = true; 
    }
    
    public void Resume()
    {
        PauseCanvas.enabled = false;
        Time.timeScale = 1; // FIXME should resume game
        Screen.lockCursor = true;
        Screen.showCursor = false; 
    }

    public void Map()
    {
        
        if (GameObject.Find("Camera").camera.depth < GameObject.Find("Main Camera").camera.depth)
        {
            GameObject.Find("Camera").camera.depth = GameObject.Find("Main Camera").camera.depth + 1;   
        }
        else
        {
            GameObject.Find("Camera").camera.depth = GameObject.Find("Main Camera").camera.depth - 1;
        }
    }
}
