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

    public static bool IsMultiPlayer;
    public static GameObject LocalPlayer;

    //LoadingIndicator loadIndicator;

    void Awake()
    {
        if (!IsMultiPlayer)
        {
            Destroy(this);
            return;
        }

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
        //loadIndicator.Toggle();

        Destroy(GameObject.FindWithTag(Tags.Player));

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
        LocalPlayer = Network.Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity, 0) as GameObject;
        LocalPlayer.AddComponent<PlayerInput>();

        GameObject.FindWithTag(Tags.MainCamera).GetComponent<Camerav2>().target = LocalPlayer.transform;

        Instantiate(HUDPrefab);
    }
}
