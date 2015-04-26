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
    WeaponSelector weaponSelector;
    
    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        weaponSelector = GameObject.FindObjectOfType<WeaponSelector>();
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

        if (playerHealth.currentHealth < 50)
        {
            LifeText.color = Color.red;
            DeathCanvas.enabled = true; 
        }        
    }

    void Update() 
    {
        TimeManager();
        LifeManager();

        int enemies = get_AI();
        GunText.text = "Kills: " + (counter - enemies) + '\n'
            + "Weapon: " + weaponSelector.SelectedWeapon + '\n'
            + "Ammo: " + weaponSelector.FirePlayer.ammo + '/' + weaponSelector.FirePlayer.magasine;

        MissionGoalText.text = "Enemies: " + enemies;
    }
}
