using UnityEngine;

public class OverlayMenu : Navigation
{
    public Canvas PauseCanvas;
    public Canvas GameOverCanvas;

    public static bool isPaused;

    Camera mapCamera;
    Camera mainCamera;
    PlayerHealth playerHealth;

    public void Start() 
    {
        mapCamera = GameObject.FindWithTag(Tags.MapCamera).GetComponent<Camera>();
        mainCamera = GameObject.FindWithTag(Tags.MainCamera).GetComponent<Camera>();
        playerHealth = GameObject.FindWithTag(Tags.Player).GetComponent<PlayerHealth>();

        Resume();
    }   

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
            GameOver();
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas.enabled)
                Resume();
            else
                Pause();                

            isPaused = PauseCanvas.enabled;
        }
   	}

    public void Pause()
    {
        PauseCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }

    public void Resume()
    {
        PauseCanvas.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void GameOver()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Map()
    {
        mapCamera.depth = mainCamera.depth + (mapCamera.depth < mainCamera.depth ? 1 : -1);
    }
}
