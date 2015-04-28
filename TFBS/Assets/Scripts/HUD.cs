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

    PlayerHealth playerHealth;
    WeaponManager weaponManager;
    
    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        weaponManager = GameObject.FindObjectOfType<WeaponManager>();
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
        LifeText.text = "HP: " + playerHealth.currentHealth;
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
                GunText.text += "Uses: " + weaponManager.ActiveWeapon.UseCount;
            else
                GunText.text += "Ammo: " + weaponManager.ActiveGun.UseCount + '/' + weaponManager.ActiveGun.MagazineCount;
        }

        MissionGoalText.text = "Enemies: " + enemies;
    }
}
