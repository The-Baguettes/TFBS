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
    public Text MoneyText;
    public Canvas DeathCanvas;

    public static float TotalTime;

    int enemyCount;
    int enemyDead;

    protected void Awake()
    {
        GetComponent<Canvas>().enabled = true;
    }

    #region EventManagement
    PlayerDamage playerDamage;
    WeaponManager playerWeaponManager;

    protected override void HookUpEvents()
    {
        GameObject player = null;

        if (!NetworkManager.IsMultiPlayer)
            player = GameObject.FindWithTag(Tags.Player);
        else if (NetworkManager.LocalPlayer == null)
            return;
        else
            player = NetworkManager.LocalPlayer;
        
        playerDamage = player.GetComponent<PlayerDamage>();

        playerDamage.Died += playerDamage_Died;
        playerDamage.HealthPointsChanged += playerDamage_HealthPointsChanged;

        playerDamage.OnInitialized(playerDamage_Initialized);

        playerWeaponManager = player.GetComponentInChildren<WeaponManager>();
        playerWeaponManager.ActiveUsed += playerWeaponManager_ActiveUsed;
        playerWeaponManager.SwitchedWeapon += playerWeaponManager_SwitchedWeapon;

        EnemyDamage[] enemyDamages = GameObject.FindObjectsOfType<EnemyDamage>();

        enemyCount = enemyDamages.Length;
        for (int i = 0; i < enemyCount; i++)
            enemyDamages[i].Died += enemyDamage_Died;

        UpdateEnemyCount();
        UpdateTotalTime();
    }

    protected override void UnHookEvents()
    {
        if (playerDamage != null)
        {
            playerDamage.Died -= playerDamage_Died;
            playerDamage.HealthPointsChanged -= playerDamage_HealthPointsChanged;
        }

        if (playerWeaponManager != null)
            playerWeaponManager.SwitchedWeapon -= playerWeaponManager_SwitchedWeapon;
    }
    #endregion

    #region EventHandlers
    void enemyDamage_Died()
    {
        --enemyCount;
        enemyDead++;
        UpdateEnemyCount();
    }

    void playerDamage_Initialized()
    {
        playerDamage_HealthPointsChanged(playerDamage.HealthPoints, 0);
    }

    void playerDamage_Died()
    {
        HealthText.text = "";
        DeathCanvas.enabled = false;
    }

    void playerDamage_HealthPointsChanged(int value, int delta)
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

    public void playerWeaponManager_ActiveUsed()
    {
        if (playerWeaponManager.ActiveGun == null)
            WeaponUseText.text = "Uses: " + playerWeaponManager.ActiveWeapon.UsesLeft;
        else
            WeaponUseText.text = "Ammo: " + playerWeaponManager.ActiveWeapon.UsesLeft + '/' + playerWeaponManager.ActiveGun.MagazineCount;
    }

    void playerWeaponManager_SwitchedWeapon()
    {
        WeaponText.text = "Weapon: " + playerWeaponManager.ActiveWeapon.name;
        playerWeaponManager.ActiveWeapon.OnInitialized(playerWeaponManager_ActiveUsed);
    }
    #endregion

    void Update()
    {
        int oldTime = (int)TotalTime;
        TotalTime += Time.deltaTime;

        if (oldTime != (int)TotalTime)
            UpdateTotalTime();

        UpdateMoney();
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

    void UpdateMoney()
    {
        string money = "Money: $" + PlayerMoney.Money;

        if (money != MoneyText.text)
            MoneyText.text = money;
    }

    public bool noEnemy()
    {
        return enemyCount == 0;
    }
    public bool enemyAlive()
    {
        return enemyDead == 0;
    }

    public int EnemyCount
    {
        get { return enemyCount; }
    }
    public int EnemyDead
    {
        get { return enemyDead; }
    }
}
