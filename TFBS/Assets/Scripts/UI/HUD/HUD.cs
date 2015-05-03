using UnityEngine;
using UnityEngine.UI;

public class HUD : BaseComponent
{
    public Text WeaponText;
    public Text WeaponUseText;
    public Text TimeText;
    public Text HealthText;
    public Text ArmorText;
    public Text EnemyCountText;
    public Text ObjectiveText;
    public Canvas DeathCanvas;

    public static float TotalTime;

    int enemyCount;

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

        EnemyDamage[] enemyDamages = GameObject.FindObjectsOfType<EnemyDamage>();

        enemyCount = enemyDamages.Length;
        for (int i = 0; i < enemyCount; i++)
            enemyDamages[i].OnDeath += enemyDamage_OnDeath;

        UpdateEnemyCount();
        UpdateTotalTime();
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
    void enemyDamage_OnDeath()
    {
        --enemyCount;
        UpdateEnemyCount();
    }

    void playerDamage_OnInitialized()
    {
        playerDamage_OnChangeHealthPoints(playerDamage.HealthPoints, 0);
    }

    void playerDamage_OnDeath()
    {
        HealthText.text = "";
        DeathCanvas.enabled = false;
    }

    void playerDamage_OnChangeHealthPoints(int value, int delta)
    {
        DeathCanvas.enabled = value < 50;

        if (value > 100)
        {
            ArmorText.text = (value - 100).ToString();
            HealthText.text = "100";
        }
        else
        {
            ArmorText.text = "";
            HealthText.text = value.ToString();
        }
    }

    public void playerWeaponManager_OnUseActive()
    {
        if (playerWeaponManager.ActiveGun == null)
            WeaponUseText.text = "Uses: " + playerWeaponManager.ActiveWeapon.UsesLeft;
        else
            WeaponUseText.text = "Ammo: " + playerWeaponManager.ActiveWeapon.UsesLeft + '/' + playerWeaponManager.ActiveGun.MagazineCount;
    }

    void playerWeaponManager_OnWeaponSwitch()
    {
        WeaponText.text = "Weapon: " + playerWeaponManager.ActiveWeapon.name;
        playerWeaponManager.ActiveWeapon.OnInitialized(playerWeaponManager_OnUseActive);
    }
    #endregion

    void Update()
    {
        int oldTime = (int)TotalTime;
        TotalTime += Time.deltaTime;

        if (oldTime != (int)TotalTime)
            UpdateTotalTime();
    }

    void UpdateEnemyCount()
    {
        EnemyCountText.text = "Enemies: " + enemyCount;
    }

    void UpdateTotalTime()
    {
        TimeText.text = "Time: " + (int)TotalTime;
    }

    public void SetObjective(string value)
    {
        if (value == null)
            // No objectives left
            ObjectiveText.enabled = false;
        else
            ObjectiveText.text = value;
    }
}
