using UnityEngine;

public class PauseMenu : Navigation
{
    public Camera mainCamera;
    public Camera mapCamera;

    protected override void Awake()
    {
        base.Awake();

        mapCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Toggle();
    }

    protected override void Hide()
    {
        base.Hide();
        HideAll();
    }

    public void Map()
    {
        mapCamera.enabled = !mapCamera.enabled;
        mainCamera.enabled = !mainCamera.enabled;
    }
}
