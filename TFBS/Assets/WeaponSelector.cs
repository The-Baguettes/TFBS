using UnityEngine;
using System.Collections;

public class WeaponSelector : MonoBehaviour {

    GameObject ak47;
    GameObject m4a1;
    public bool ak47_isactive;
    public bool m4a1_isactive;
	void Start () 
    {
        ak47 = GameObject.FindWithTag("Ak47");
        m4a1 = GameObject.FindWithTag("M4A1");
        m4a1.gameObject.SetActive(true);
        ak47.gameObject.SetActive(false);
	}	
	void Update () 
    {
        WeaponSelect();
	}
    void WeaponSelect() 
    {
        if (Input.GetKeyDown("1")) 
        {
            m4a1.gameObject.SetActive(true);
            ak47.gameObject.SetActive(false);
            m4a1_isactive = true;
            ak47_isactive = false;
        }
        if (Input.GetKeyDown("2")) 
        {
            m4a1.gameObject.SetActive(false);
            ak47.gameObject.SetActive(true);
            m4a1_isactive = false;
            ak47_isactive = true;
        }
    }
}
