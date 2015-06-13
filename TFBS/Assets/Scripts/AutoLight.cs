using UnityEngine;
using System.Collections;

public class AutoLight : MonoBehaviour
{

    bool contact;
    public GameObject Candle1;
    public GameObject Candle2;
    // Update is called once per frame
    IEnumerator LightSystem()
    {
        for (int i = 0; i < Candle1.transform.childCount; i++)
        {
            Candle1.transform.GetChild(i).gameObject.SetActive(true);
            Candle2.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            StartCoroutine(LightSystem());
            contact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            contact = false;
        }
    }
}
