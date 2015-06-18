using UnityEngine;

public class GameOverMenu : MenuBase
{
    PlayerDamage playerDamage;

    protected override void HookUpEvents()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);
        playerDamage = player.GetComponent<PlayerDamage>();

        playerDamage.Died += playerDamage_Died;
    }

    void playerDamage_Died()
    {
        Show();
    }

    public void TryAgain()
    {
        playerDamage.Reset();
        SceneManager.ReloadScene();
    }
}
