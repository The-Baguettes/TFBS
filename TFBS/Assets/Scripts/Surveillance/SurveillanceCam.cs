using System.Collections.Generic;
using UnityEngine;

public class SurveillanceCam : BaseComponent
{
    public float RotateAngle;
    public float Speed = 10;

    public delegate void PlayerSpottedHandler(Vector3 spottedAt);
    public static event PlayerSpottedHandler PlayerSpotted;

    float minAngle;
    float maxAngle;
    float targetAngle;

    Vector3 currentAngle;
    float animationStartTime;

    protected void Awake()
    {
        minAngle = transform.eulerAngles.y - RotateAngle / 2;
        maxAngle = transform.eulerAngles.y + RotateAngle / 2;

        // Make sure the angles are positive
        minAngle = (minAngle + 360) % 360;
        maxAngle = (maxAngle + 360) % 360;

        targetAngle = minAngle;
    }

    protected override void Start()
    {
        Camera camera = GetComponentInChildren<Camera>();
        camera.enabled = false;
        camera.depth = GameObject.FindWithTag(Tags.MainCamera).GetComponent<Camera>().depth + 1;

        base.Start();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            PlayerSpotted(col.transform.position);
    }

    void Update()
    {
        if (Time.time <= animationStartTime)
            return;

        float y = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * Speed);
        currentAngle.Set(transform.eulerAngles.x, y, transform.eulerAngles.z);

        transform.eulerAngles = currentAngle;

        if (y != targetAngle)
            return;

        animationStartTime = Time.time + 2;

        if (targetAngle == minAngle)
            targetAngle = maxAngle;
        else
            targetAngle = minAngle;
    }
}
