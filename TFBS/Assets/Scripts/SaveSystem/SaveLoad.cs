using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static bool IsLoadingSave { get; private set; }

    static bool isLoadingSave;

    public static bool HasSave()
    {
        return PlayerPrefs.HasKey("Level");
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Level", Application.loadedLevel);

        GameObject player = GameObject.FindWithTag(Tags.Player);
        PlayerDamage playerDamage = player.GetComponent<PlayerDamage>();

        PlayerPrefs.SetFloat("Time", HUD.TotalTime);

        PlayerPrefs.SetFloat("PosX", player.transform.position.x);
        PlayerPrefs.SetFloat("PosY", player.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", player.transform.position.z);

        PlayerPrefs.SetFloat("RotX", player.transform.rotation.x);
        PlayerPrefs.SetFloat("RotY", player.transform.rotation.y);
        PlayerPrefs.SetFloat("RotZ", player.transform.rotation.z);
        PlayerPrefs.SetFloat("RotW", player.transform.rotation.w);

        PlayerPrefs.SetInt("HP", playerDamage.HealthPoints);
        PlayerPrefs.SetInt("Money", PlayerMoney.Money);
    }

    public void Load()
    {
        isLoadingSave = true;
        SceneManager.LoadScene((Scene)PlayerPrefs.GetInt("Level"));
    }

    void OnLevelWasLoaded()
    {
        if (!isLoadingSave || Application.loadedLevel != PlayerPrefs.GetInt("Level"))
            return;

        isLoadingSave = false;

        GameObject player = GameObject.FindWithTag(Tags.Player);
        PlayerDamage playerDamage = player.GetComponent<PlayerDamage>();

        HUD.TotalTime = PlayerPrefs.GetFloat("Time");

        float x = PlayerPrefs.GetFloat("PosX");
        float y = PlayerPrefs.GetFloat("PosY");
        float z = PlayerPrefs.GetFloat("PosZ");
        player.transform.position = new Vector3(x, y, z);

        float w;
        x = PlayerPrefs.GetFloat("RotX");
        y = PlayerPrefs.GetFloat("RotY");
        z = PlayerPrefs.GetFloat("RotZ");
        w = PlayerPrefs.GetFloat("RotW");
        player.transform.rotation = new Quaternion(x, y, z, w);

        playerDamage.SetHealthPoints(PlayerPrefs.GetInt("HP"));
        PlayerMoney.Money = PlayerPrefs.GetInt("Money");
    }

    void OnDestroy()
    {
        IsLoadingSave = isLoadingSave;
    }
}
