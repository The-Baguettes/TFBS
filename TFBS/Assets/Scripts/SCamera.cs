using UnityEngine;
using System.Collections;

public class SCamera : MonoBehaviour
{
    #region Coordinates
    public float XOffsetFromCenter;
    public float YOffsetFromCenter;
    public float ZOffsetFromCenter;
    #endregion
    public bool isPlayer;
    Vector3 positionUp;
    Vector3 positionDown;
    public float smooth;
    public GameObject ToMove;
    bool final;
    float animationProgress = 0.0f;

	void Start () {
        GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
        positionUp = ToMove.transform.position;
        positionDown = new Vector3(positionUp.x + XOffsetFromCenter, positionUp.y + YOffsetFromCenter, positionUp.z + ZOffsetFromCenter);
        final = false;        
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.Player)
            isPlayer = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == Tags.Player)
        {
            isPlayer = false;
        }
    }

    IEnumerator Displacement()
    {
            yield return new WaitForSeconds(5f);
    }



	void Update () {

        if (final)
        {
            if (ToMove.transform.position == positionDown)
            {
                final = !final;
            }
            else
            {
                if (ToMove.transform.position == positionUp)
                {
                    StartCoroutine(Displacement());
                    animationProgress = 0.0f;
                    ToMove.transform.position = new Vector3(ToMove.transform.position.x - 0.0001f, ToMove.transform.position.y - 0.0001f, ToMove.transform.position.z - 0.0001f);
                }
                else
                {
                    ToMove.transform.position = Vector3.Lerp(positionUp, positionDown, animationProgress / smooth);
                }
            }
        }
        if (!final)
        {
            if (ToMove.transform.position == positionUp)
            {
                final = !final;
            }
            else
            {
                if (ToMove.transform.position == positionDown)
                {
                    StartCoroutine(Displacement());
                    animationProgress = 0.0f;
                    ToMove.transform.position = new Vector3(ToMove.transform.position.x + 0.0001f, ToMove.transform.position.y + 0.0001f, ToMove.transform.position.z + 0.0001f);
                }
                else
                {
                    ToMove.transform.position = Vector3.Lerp(positionDown, positionUp, animationProgress / smooth);
                }
            }
        }
      
	}
}
