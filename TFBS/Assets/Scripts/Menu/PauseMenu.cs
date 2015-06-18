using UnityEngine;

public class PauseMenu : MenuBase
{
    public GameObject mainCamera;
    public GameObject mapCamera;

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
        mapCamera.SetActive(!mapCamera.activeSelf);
        mainCamera.SetActive(!mainCamera.activeSelf);
    }
}
