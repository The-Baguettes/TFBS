using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text GunText;
    public Text TimeText;
    public Text LifeText;
    public Text MissionGoalText;
    public Canvas DeathCanvas;
    
    int counter;

    PlayerDamage playerDamage;
    WeaponManager weaponManager;
    
    void Start()
    {
        GameObject player = GameObject.FindWithTag(Tags.Player);

        playerDamage = player.GetComponent<PlayerDamage>();
        weaponManager = player.GetComponentInChildren<WeaponManager>();
        counter = get_AI();
    }

    int get_AI()
    {
        return GameObject.FindGameObjectsWithTag(Tags.Enemy).Length;
    }

    void TimeManager()
    {
        TimeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }

    void LifeManager()
    {
        LifeText.text = "HP: " + playerDamage.HealthPoints;
    }

    void Update() 
    {
        TimeManager();
        LifeManager();

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
