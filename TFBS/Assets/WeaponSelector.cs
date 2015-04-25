using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public string SelectedWeapon { get; private set; }
    public FirePlayer FirePlayer { get; private set; }

    GameObject ak47;
    GameObject m4a1;

    GameObject curr;

    void Start()
    {
        ak47 = GameObject.FindWithTag(Tags.AK47);
        m4a1 = GameObject.FindWithTag(Tags.M4A1);

        curr = ak47; // To deactivate it
        SwitchTo(m4a1);
    }

    void Update() 
    {
        if (Input.GetKeyDown("1"))
            SwitchTo(m4a1);
        else if (Input.GetKeyDown("2"))
            SwitchTo(ak47);
    }

    void SwitchTo(GameObject weapon)
    {
        curr.SetActive(false);
    
        curr = weapon;
        curr.SetActive(true);

        SelectedWeapon = curr.name;
        FirePlayer = curr.transform.FindChild("Spawn").GetComponent<FirePlayer>();
    }
}
