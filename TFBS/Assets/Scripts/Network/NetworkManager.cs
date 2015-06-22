using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    const string typeName = "TFBS";
    const string gameName = "The Game";

    public GameObject playerPrefab;

    void Awake()
    {
        MasterServer.ipAddress = "127.0.0.1";
    }

    void Start()
    {
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
        SpawnPlayer(-2, 1, 0);
    }

    void OnConnectedToServer()
    {
        SpawnPlayer(2, 1, 0);
    }

    void SpawnPlayer(float x, float y, float z)
    {
        GameObject player = Network.Instantiate(playerPrefab, new Vector3(x, y, z), Quaternion.identity, 0) as GameObject;
        player.AddComponent<PlayerInput>();
        player.AddComponent<PlayerNetworking>();

        GameObject mainCam = GameObject.FindWithTag(Tags.MainCamera);
        Camerav2 cam = mainCam.AddComponent<Camerav2>();

        cam.target = player.transform;
        cam.here = mainCam.GetComponent<Camera>();
    }
}
