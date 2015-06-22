using UnityEngine.UI;


public class MainMenu : Navigation
{
    Button loadButton;

    protected override void Awake()
    {
        base.Awake();

        loadButton = transform.FindChild("Load").GetComponent<Button>();
    }

    protected override void Start()
    {
        base.Start();

        if (SceneManager.LoadedScene == Scene.MainMenu)
            Show();
    }

    protected override void Show()
    {
        base.Show();

        loadButton.interactable = SaveLoad.HasSave();
    }

    public void Play()
    {
        NetworkManager.IsMultiPlayer = false;
        SceneManager.LoadScene(MetaScene.FirstLevel);
    }

    public void MultiPlayer()
    {
        NetworkManager.IsMultiPlayer = true;
        SceneManager.LoadScene(Scene.Floor1);
    }
}
