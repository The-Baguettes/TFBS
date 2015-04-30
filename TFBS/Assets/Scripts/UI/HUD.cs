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
        playerDamage.OnAddHealthPoints += playerDamage_OnAddHealthPoints;
        playerDamage.OnRemoveHealthPoints += playerDamage_OnRemoveHealthPoints;
    }

    protected override void UnHookEvents()
    {
        playerDamage.OnDeath += playerDamage_OnDeath;
        playerDamage.OnAddHealthPoints -= playerDamage_OnAddHealthPoints;
        playerDamage.OnRemoveHealthPoints -= playerDamage_OnRemoveHealthPoints;
    }
    #endregion

    #region EventHandlers
    void playerDamage_OnDeath()
    {
        LifeText.text = "You died";
        DeathCanvas.enabled = false;
    }

    void playerDamage_OnAddHealthPoints(int value, int delta)
    {
        if (value > 50)
            DeathCanvas.enabled = false;
    }

    void playerDamage_OnRemoveHealthPoints(int value, int delta)
    {

        if (value > 100)
        {
            LifeText.text = "HP: 100";
            ArmorManager(value - 100);
        }
        else
        {
            ArmorText.text = "No armor";
            LifeText.text = "HP: " + value;

            if (value < 50)
                DeathCanvas.enabled = true;
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
