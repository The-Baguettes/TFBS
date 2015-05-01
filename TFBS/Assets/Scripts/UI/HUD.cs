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

    #region EventManagement
    PlayerDamage playerDamage;
    WeaponManager playerWeaponManager;

    protected override void HookUpEvents()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);
        playerDamage = player.GetComponent<PlayerDamage>();

        playerDamage.OnDeath += playerDamage_OnDeath;
        playerDamage.OnChangeHealthPoints += playerDamage_OnChangeHealthPoints;

        playerDamage.OnInitialized(playerDamage_OnInitialized);

        playerWeaponManager = player.GetComponentInChildren<WeaponManager>();
        playerWeaponManager.OnWeaponSwitch += playerWeaponManager_OnWeaponSwitch;
    }

    protected override void UnHookEvents()
    {
        if (playerDamage != null)
        {
            playerDamage.OnDeath -= playerDamage_OnDeath;
            playerDamage.OnChangeHealthPoints -= playerDamage_OnChangeHealthPoints;
        }

        if (playerWeaponManager != null)
            playerWeaponManager.OnWeaponSwitch -= playerWeaponManager_OnWeaponSwitch;
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

    void playerWeaponManager_OnWeaponSwitch(BaseWeapon weapon, BaseGun gun)
    {
        GunText.text = "Weapon: " + weapon.name + '\n';

        if (gun == null)
            GunText.text += "Uses: " + weapon.UsesLeft;
        else
            GunText.text += "Ammo: " + weapon.UsesLeft + '/' + gun.MagazineCount;
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

        //objectives of the mission, here example of a simple mission
        MissionGoalText.text = "Objectives: Kill the ennemies.\n\n\n";
        MissionGoalText.text += "Enemies left: " + get_AI();
    }
}
