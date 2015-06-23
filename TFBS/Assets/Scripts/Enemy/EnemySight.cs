using UnityEngine;

class EnemySight : MonoBehaviour
{
    const int fieldOfView = 160 / 2;

    public event SurveillanceCam.PlayerSpottedHandler PlayerInSight;

    void OnTriggerStay(Collider col)
    {
        if (PlayerInSight != null && col.tag == Tags.Player && (IsVisible(col) || Vector3.Distance(transform.position, col.transform.position) < 5))
            PlayerInSight(col.transform.position);
    }

    public bool IsVisible(Collider col)
    {
        return isInFieldOfView(col) && isInSight(col);
    }

    bool isInFieldOfView(Collider col)
    {
        return Vector3.Angle(col.transform.position - transform.position, transform.forward) < fieldOfView;
    }

    bool isInSight(Collider col)
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.forward, out hit) && hit.collider == col;
    }
}
