using UnityEngine;
using UnityEngine.UI;

public class HUD : BaseComponent
{
    public Text WeaponText;
    public Text WeaponUseText;
    public Text TimeText;
    public Text LifeText;
    public Text ArmorText;
    public Text MissionGoalText;
    public Canvas DeathCanvas;
    public int AddTime;
    public int time;
    public string Objective = "Kill all the ennemies";

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
        playerWeaponManager.OnUseActive += playerWeaponManager_OnUseActive;
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

    void playerWeaponManager_OnUseActive(Transform target)
    {
        if (playerWeaponManager.ActiveGun == null)
            WeaponUseText.text = "Uses: " + playerWeaponManager.ActiveWeapon.UsesLeft;
        else
            WeaponUseText.text = "Ammo: " + playerWeaponManager.ActiveWeapon.UsesLeft + '/' + playerWeaponManager.ActiveGun.MagazineCount;
    }

    void playerWeaponManager_OnWeaponSwitch()
    {
        WeaponText.text = "Weapon: " + playerWeaponManager.ActiveWeapon.name;
        playerWeaponManager_OnUseActive(null);
    }
    #endregion

    int get_AI()
    {
        return GameObject.FindGameObjectsWithTag(Tags.Enemy).Length;
    }

    void TimeManager()
    {
        time = (int)Time.timeSinceLevelLoad;
        int print_time = time + AddTime;
        TimeText.text = "Time: " + print_time;
    }

    void ArmorManager(int armor)
    {
        ArmorText.text = "Armor: " + armor;
    }

    void Update()
    {
        TimeManager();

        //objectives of the mission, here example of a simple mission
        MissionGoalText.text ="Objective: " + Objective + "\n\n\n";
        MissionGoalText.text += "Enemies left: " + get_AI();
    }
}
