using UnityEngine;

public class OverlayMenu : Navigation
{
    public Canvas PauseCanvas;
    public Canvas GameOverCanvas;

    public static bool isPaused;

    Canvas deathCanvas;
    Camera mapCamera;
    Camera mainCamera;
    PlayerDamage playerDamage;

    public void Start() 
    {
        deathCanvas = FindObjectOfType<HUD>().DeathCanvas;
        mapCamera = GameObject.FindWithTag(Tags.MapCamera).GetComponent<Camera>();
        mainCamera = GameObject.FindWithTag(Tags.MainCamera).GetComponent<Camera>();
        playerDamage = GameObject.FindWithTag(Tags.Player).GetComponent<PlayerDamage>();

        Resume();
    }   

    void Update()
    {
        if (playerDamage.HealthPoints <= 0)
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
        deathCanvas.enabled = false;
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

        deathCanvas.enabled = playerDamage.HealthPoints < 50;
    }

    public void GameOver()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        deathCanvas.enabled = false;
    }

    public void Map()
    {
        mapCamera.depth = mainCamera.depth + (mapCamera.depth < mainCamera.depth ? 1 : -1);
    }
}
