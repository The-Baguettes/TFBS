using UnityEngine;
using UnityEngine.UI;

public class HealthBar : BaseComponent
{
    Slider slider;

    protected override void OnStart()
    {
        slider = GetComponent<Slider>();
    }

    #region EventManagement
    PlayerDamage playerDamage;

    protected override void HookUpEvents()
    {
        playerDamage = GameObject.FindObjectOfType<PlayerDamage>();
        playerDamage.OnChangeHealthPoints += playerDamage_OnChangeHealthPoints;

        playerDamage.OnInitialized(playerDamage_OnInitialized);
    }

    protected override void UnHookEvents()
    {
        if (playerDamage != null)
            playerDamage.OnChangeHealthPoints -= playerDamage_OnChangeHealthPoints;
    }
    #endregion

    #region EventHandlers
    void playerDamage_OnChangeHealthPoints(int value, int delta)
    {
        if (value > 100)
            slider.value = 100;
        else
            slider.value = value;
    }

    void playerDamage_OnInitialized()
    {
        playerDamage_OnChangeHealthPoints(playerDamage.HealthPoints, 0);
    }
    #endregion
}
