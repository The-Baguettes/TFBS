using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text Txt;

    PlayerHealth playerHealth;
    WeaponSelector weaponSelector;
    
    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        weaponSelector = GameObject.FindObjectOfType<WeaponSelector>();
    }

    void Update() 
    {
        Txt.text = "HP: " + playerHealth.currentHealth + '\n'
            + "Weapon: " + weaponSelector.SelectedWeapon + '\n'
            + "Ammo: " + weaponSelector.FirePlayer.ammo + '/' + weaponSelector.FirePlayer.magasine + '\n';
        //    +"Kill:" + "??";
    }
}
