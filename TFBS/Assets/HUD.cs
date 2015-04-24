using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{
    public Text Txt;
    float score;
    Player Player;
    void Start ()
    {

    }

    void Update() 
        // TO FIX Find how to get life component at each Update, nb of kills and the selected weapon 
    {
        Txt.text = "Actual life :" + score + '\n' + "Selected Weapon :" + '\n' +  "Kill :";
    }
}
