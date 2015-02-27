using UnityEngine;

public class OverlayMenu : Navigation
{
    public Canvas PauseCanvas; //Our scene canvas
    public Canvas GameOverCanvas;

    public void Start() 
    {
        Screen.lockCursor = true;
        Screen.showCursor = false;
    }

    public void PauseUpdate()
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

    public void GameOver()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Screen.lockCursor = false;
        Screen.showCursor = true;
        if (Input.anyKeyDown)
        {
            Application.LoadLevel("MainMenu");
        }
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
