using UnityEngine;
using System.Collections;

public class AutoLight : MonoBehaviour
{
    public GameObject Candle1;
    public GameObject Candle2;
    public float speed;
    // Update is called once per frame
    IEnumerator LightSystem()
    {
        for (int i = 0; i < Candle1.transform.childCount; i++)
        {
            Candle1.transform.GetChild(i).gameObject.SetActive(true);
            Candle2.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(speed);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            StartCoroutine(LightSystem());
        }
    }
}
