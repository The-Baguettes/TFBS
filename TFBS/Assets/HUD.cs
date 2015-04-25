using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text GunText;
    public Text TimeText;
    public Text LifeText;
    float clock = 0;
    int bullet = 0;
    int counter = 0;
    int kill;
    GameObject []AI;
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
        AI = GameObject.FindGameObjectsWithTag("Enemy");
        return AI.Length;
    }
    void TimeManager()
    {
        clock += Time.deltaTime;
        TimeText.text = "Time :" + clock;
    }

    void LifeManager()
    {
        LifeText.text = "HP :" + playerHealth.currentHealth;
        if(playerHealth.currentHealth < 50)
        {
            LifeText.color = Color.red;
            LifeText.text = "HP :" + playerHealth.currentHealth;
        }
    }

    void Update() 
    {
        TimeManager();
        LifeManager();
        if(Input.GetMouseButtonDown(0))
        {
            bullet += 1;
        }
        if(get_AI() < counter)
        {
            kill = counter - get_AI();
        }
        GunText.text = "Used bullets : " + bullet +
            '\n' + "Weapon : " + weaponSelector.SelectedWeapon + '\n' + "Kills : " + kill + '\n' +
            "Ammo :" + weaponSelector.FirePlayer.ammo + '/' + weaponSelector.FirePlayer.magasine  + 
            '\n' + '\n' + "Number of remaining AI:" + get_AI();

    }
}
