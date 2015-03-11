using UnityEngine;


public class OverlayMenu : Navigation
{
    public Canvas PauseCanvas; //Our scene canvas
    public Canvas GameOverCanvas;

    public static bool isPaused;

    public void Start() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1;
    }   

    void Update()
    {
        isPaused = PauseCanvas.enabled;
        // If the escape key is pressed then the following instruction is loaded
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas.enabled)
            {
                Resume();
            }
            else
            {
                Pause();                
            }
        }
        ScreenGameOver();
   	}

    public void Pause()
    {
        PauseCanvas.enabled = true;
        Time.timeScale = 0; // FIXME should pause game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }

    public void Resume()
    {
        PauseCanvas.enabled = false;
        Time.timeScale = 1; // FIXME should resume game
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

    public void ScreenGameOver ()
    {        
        if (GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerHealth>().currentHealth <= 0)  
        {
            GameOver();
        }        
    }

    public void Map()
    {
        Camera camera = GameObject.Find("Camera").GetComponent<Camera>();
        Camera main_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        camera.depth = main_camera.depth + (camera.depth < main_camera.depth ? 1 : -1);
    }
}
