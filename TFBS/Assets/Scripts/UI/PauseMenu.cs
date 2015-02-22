using UnityEngine;
using UnityEditor;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public Canvas PauseCanvas; //Our scene canvas 

	void Start () 
    {
        Screen.lockCursor = true;
        Screen.showCursor = false; 
	}

    public void Settings()
    {
        SceneManager.LoadScene(Scene.SettingsMenu);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu);
    }

    public void Quit()
    {
        if (Application.isEditor)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
	
    public void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseCanvas.enabled) // If the key echap is pressed then the following instruction is loaded
        {
            PauseCanvas.enabled = false;
            Time.timeScale = 1; // Time scale won't working 
            Screen.lockCursor = true;
            Screen.showCursor = false; 
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.enabled = true;
            Time.timeScale = 0; // Time scale won't working 
            Screen.lockCursor = false;
            Screen.showCursor = true; 
        }
   	}

    public void Unpaused_espace ()
    {
        if (PauseCanvas.enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.enabled = false;
            Time.timeScale = 1;
            Screen.lockCursor = true;
            Screen.showCursor = false; 
        }
    }

    public void Unpaused ()
    {
        PauseCanvas.enabled = false;
        Time.timeScale = 1;
        Screen.lockCursor = true;
        Screen.showCursor = false; 
    }
}
