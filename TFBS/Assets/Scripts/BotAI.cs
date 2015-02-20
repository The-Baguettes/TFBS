using UnityEngine;

public class BotAI : MonoBehaviour
{
    Transform Leader;
    float AIspeed = 3.5f;
    float MaxDistance = 4.0f;
    float MiniDistance = 2.0f;

    void Start()
    {
        Leader = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        AI();
    }

    void AI()
    {
        if (Vector3.Distance(transform.position, Leader.position) >= MiniDistance)
        {
            transform.position += transform.forward * AIspeed * Time.deltaTime;
            transform.LookAt(Leader);
        }

		if (Vector3.Distance(transform.position, Leader.position) >= MaxDistance)
            Patrol();
    }

	void Patrol()
    {
        
    }
}
