using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : BaseComponent
{
    public Text GunText;
    public Text TimeText;
    public Text LifeText;
    public Text ArmorText;
    public Text MissionGoalText;
    public Canvas DeathCanvas;

    int counter;

    WeaponManager weaponManager;

    sealed protected override void OnStart()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);
        
        weaponManager = player.GetComponentInChildren<WeaponManager>();
        counter = get_AI();
    }

    #region EventRegistration
    PlayerDamage playerDamage;

    protected override void HookUpEvents()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);
        playerDamage = player.GetComponent<PlayerDamage>();

        playerDamage.OnDeath += playerDamage_OnDeath;
        playerDamage.OnChangeHealthPoints += playerDamage_OnChangeHealthPoints;

        playerDamage.OnInitialized(playerDamage_OnInitialized);
    }

    protected override void UnHookEvents()
    {
        playerDamage.OnDeath -= playerDamage_OnDeath;
        playerDamage.OnChangeHealthPoints -= playerDamage_OnChangeHealthPoints;
    }
    #endregion

    #region EventHandlers
    void playerDamage_OnInitialized()
    {
        playerDamage_OnChangeHealthPoints(playerDamage.HealthPoints, 0);
    }

    void playerDamage_OnDeath()
    {
        LifeText.text = "You died";
        DeathCanvas.enabled = false;
    }

    void playerDamage_OnChangeHealthPoints(int value, int delta)
    {
        DeathCanvas.enabled = value < 50;

        if (value > 100)
        {
            LifeText.text = "HP: 100";
            ArmorManager(value - 100);
        }
        else
        {
            ArmorText.text = "No armor";
            LifeText.text = "HP: " + value;
        }
    }
    #endregion

    int get_AI()
    {
        return GameObject.FindGameObjectsWithTag(Tags.Enemy).Length;
    }

    void TimeManager()
    {
        TimeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }

    void ArmorManager(int armor)
    {
        ArmorText.text = "Armor: " + armor;
    }

    void Update()
    {
        TimeManager();

        int enemies = get_AI();
        GunText.text = "Kills: " + (counter - enemies) + '\n';
        if (weaponManager.ActiveWeapon != null)
        {
            GunText.text += "Weapon: " + weaponManager.ActiveWeapon.name + '\n';

            if (weaponManager.ActiveGun == null)
                GunText.text += "Uses: " + weaponManager.ActiveWeapon.UsesLeft;
            else
                GunText.text += "Ammo: " + weaponManager.ActiveGun.UsesLeft + '/' + weaponManager.ActiveGun.MagazineCount;
        }

        MissionGoalText.text = "Enemies: " + enemies;
    }
}
