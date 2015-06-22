using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    const string typeName = "TFBS";
    const string gameName = "The Game";

    public GameObject PlayerPrefab;

    public static bool IsMultiPlayer;

    List<Transform> availableSpawns;

    void Awake()
    {
        MasterServer.ipAddress = "127.0.0.1";

        availableSpawns = new List<Transform>(transform.childCount);
        GetComponentsInChildren<Transform>(availableSpawns);
    }

    void Start()
    {
        if (!IsMultiPlayer)
        {
            Destroy(this);
            return;
        }

        Destroy(GameObject.FindWithTag(Tags.MainCamera));
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
        StartCoroutine(SpawnPlayer());
    }

    void OnConnectedToServer()
    {
        StartCoroutine(SpawnPlayer());
    }

    IEnumerator SpawnPlayer()
    {
        while (availableSpawns.Count == 0)
            yield return new WaitForSeconds(.1f);

        Transform spawn;
        lock (availableSpawns)
        {
            int i = Random.Range(0, availableSpawns.Count);
            spawn = availableSpawns[i];
            availableSpawns.RemoveAt(i);
        }

        GameObject player = Network.Instantiate(PlayerPrefab, spawn.position, spawn.rotation, 0) as GameObject;
        player.AddComponent<PlayerInput>();
        player.AddComponent<PlayerNetworking>();

        GameObject mainCam = GameObject.FindWithTag(Tags.MainCamera);
        Camerav2 cam = mainCam.AddComponent<Camerav2>();

        cam.target = player.transform;
        cam.here = mainCam.GetComponent<Camera>();

        yield return new WaitForSeconds(5);
        lock (availableSpawns)
            availableSpawns.Add(spawn);
    }
}
