using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    const string typeName = "TFBS";
    const string gameName = "The Game";

    public GameObject HUDPrefab;
    public GameObject PlayerPrefab;
    public GameObject[] ObjectsToDestroy;
    public MonoBehaviour[] ScriptsToDisable;

    public static bool IsMultiPlayer = true;

    //LoadingIndicator loadIndicator;

    void Awake()
    {
        MasterServer.ipAddress = "127.0.0.1";

        PlayerNetworking.AvailableSpawns = new List<Transform>(transform.childCount);
        GetComponentsInChildren<Transform>(PlayerNetworking.AvailableSpawns);
        PlayerNetworking.AvailableSpawns.RemoveAt(0);

        for (int i = 0; i < ObjectsToDestroy.Length; i++)
            Destroy(ObjectsToDestroy[i]);

        for (int i = 0; i < ScriptsToDisable.Length; i++)
            Destroy(ScriptsToDisable[i]);

        //loadIndicator = GameObject.FindObjectOfType<LoadingIndicator>();
    }

    void Start()
    {
        if (!IsMultiPlayer)
        {
            Destroy(this);
            return;
        }

        //loadIndicator.Toggle();

        Destroy(GameObject.FindWithTag(Tags.Player));

        GameObject common = GameObject.Find("Common");
        Destroy(common.transform.FindChild("HUD"));

        NetworkConnectionError err = Network.InitializeServer(4, 25000, !Network.HavePublicAddress());

        if (err == NetworkConnectionError.NoError)
            MasterServer.RegisterHost(typeName, gameName);
        else
            MasterServer.RequestHostList(typeName);
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.HostListReceived)
        {
            HostData[] hostList = MasterServer.PollHostList();
            if (hostList.Length != 0)
                Network.Connect(hostList[0]);
            else
                MasterServer.RequestHostList(typeName);
        }
    }

    void OnServerInitialized()
    {
        SpawnPlayer();
    }

    void OnConnectedToServer()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject player = Network.Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity, 0) as GameObject;
        player.AddComponent<PlayerInput>();

        GameObject.FindWithTag(Tags.MainCamera).GetComponent<Camerav2>().target = player.transform;

        Instantiate(HUDPrefab);
    }
}
