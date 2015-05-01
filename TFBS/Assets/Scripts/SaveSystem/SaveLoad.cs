using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class SaveLoad : MonoBehaviour {
    static string folder;

    static Vector3 position;
    static Quaternion rotation;
    static int currenthealth;
    static float time;

	void Start () {
        folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        folder = Path.Combine(folder, "TFBS");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
	}
	
    string SaveInformation()
    {
        string level = Application.loadedLevel.ToString();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        string position =  player.transform.position.x + "|" + player.transform.position.y + "|" + player.transform.position.z + "|";
        string rotation = player.transform.rotation.x + "|" + player.transform.rotation.y + "|" + player.transform.rotation.z + "|" + player.transform.rotation.w + "|";
        string health = GameObject.FindObjectOfType<PlayerDamage>().HealthPoints.ToString();
        string result = level + "\r\n" + position + "\r\n" + rotation + "\r\n" + health;
        return result; 
    }

    public void Save()
    {
        StreamWriter sav = new StreamWriter(File.Create("save.txt"));
        sav.Write(SaveInformation());
        sav.Close();
    }

    static float ToFloat(string a)
    {
        float result;
        float.TryParse(a, out result);
        return result;
    }

    public void Load()
    {
        StreamReader loa = new StreamReader("save.txt");
        string lvl = loa.ReadLine();
        string pos = loa.ReadLine();
        string rot = loa.ReadLine();
        string hea = loa.ReadLine();
        position = ToVector3(pos);
        rotation = ToQuaternion(rot);
        currenthealth = (int)ToFloat(hea);
        DontDestroyOnLoad(gameObject);        
        SceneManager.LoadScene((Scene)ToFloat(lvl));
    }

    Vector3 ToVector3(string a) //transform a string to a Vector3
    {
        List<string> pos2 = LoadSeparator(a);
        return new Vector3(ToFloat(pos2[0]), ToFloat(pos2[1]), ToFloat(pos2[2]));
    }

    Quaternion ToQuaternion(string a) //transform a string to a Vector3
    {
        List<string> pos2 = LoadSeparator(a);
        return new Quaternion(ToFloat(pos2[0]), ToFloat(pos2[1]), ToFloat(pos2[2]), ToFloat(pos2[3]));
    }

    void OnLevelWasLoaded()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = position;
        player.transform.rotation = rotation;

        Destroy(gameObject);
    }

    static List<string> LoadSeparator(string a)
    {
        string memoire = "";
        char delimiter;
        List<string> list = new List<string>();
        for (int i = 0; i < a.Length; i++)
        {
            delimiter = a[i];
            if(delimiter == '|')
            {
                list.Add(memoire);
                memoire = "";
            }
            else
            {
                memoire = memoire + a[i];
            }          
        }
        return list;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
