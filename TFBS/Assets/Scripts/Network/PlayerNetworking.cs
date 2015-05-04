using UnityEngine;

public class PlayerNetworking : MonoBehaviour
{
    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        print(666);

        Vector3 syncPosition = transform.position;

        if (stream.isWriting)
        {
            syncPosition = transform.position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            transform.position = syncPosition;
        }
    }
}
