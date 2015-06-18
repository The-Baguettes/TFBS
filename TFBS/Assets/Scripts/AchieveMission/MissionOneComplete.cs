﻿using UnityEngine;
using System.Collections;

public class MissionOneComplete : MonoBehaviour
{
    public GameObject bombA;
    public GameObject bombB;
    public GameObject bombC;
    public GameObject bombD;
    public GameObject bombE;

    public GameObject light;
    public Transform explosion;
    public Transform destructible;

    GameObject AI;
    GameObject bombSound;

    bool contact;

    void Start()
    {
        AI = GameObject.Find("Ennemies");
        bombSound = GameObject.Find("BombSound");
        contact = false;
        light.GetComponent<Light>().enabled = false;
    }

    void OnGUI()
    {
        if (bombA.active && bombB.active && bombC.active && bombD.active && bombE.active)
        {
            light.GetComponent<Light>().enabled = true;
            if (contact)
            {
                GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height / 2 - 50, 250, 200), "Press 'F' to activate bombs");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //all object movable
                    foreach (Transform childa in destructible)
                    {
                        if (childa.GetComponent<Rigidbody>() != null)
                        {
                            childa.GetComponent<Rigidbody>().isKinematic = false;
                        }
                        foreach (Transform child0 in childa)
                        {
                            if (child0.GetComponent<Rigidbody>() != null)
                            {
                                child0.GetComponent<Rigidbody>().isKinematic = false;
                            }
                            foreach (Transform child in child0)
                            {
                                if (child.GetComponent<Rigidbody>() != null)
                                {
                                    child.GetComponent<Rigidbody>().isKinematic = false;
                                }
                                foreach (Transform child2 in child)
                                {
                                    if (child2.GetComponent<Rigidbody>() != null)
                                    {
                                        child2.GetComponent<Rigidbody>().isKinematic = false;
                                    }
                                    foreach (Transform child3 in child2)
                                    {
                                        if (child3.GetComponent<Rigidbody>() != null)
                                        {
                                            child3.GetComponent<Rigidbody>().isKinematic = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //all AI disappear
                    Destroy(AI);

                    //animation
                    Instantiate(explosion, bombA.transform.position, bombA.transform.rotation);
                    Instantiate(explosion, bombB.transform.position, bombB.transform.rotation);
                    Instantiate(explosion, bombC.transform.position, bombC.transform.rotation);
                    Instantiate(explosion, bombD.transform.position, bombD.transform.rotation);
                    Instantiate(explosion, bombE.transform.position, bombE.transform.rotation);

                    bombA.active = false;
                    bombB.active = false;
                    bombC.active = false;
                    bombD.active = false;
                    bombE.active = false;

                    light.GetComponent<Light>().enabled = false;
                    bombSound.GetComponent<AudioSource>().Play();

                    Missions.missionCompleted = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
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

    //to facilitate test
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //all object movable
            foreach (Transform childa in destructible)
            {
                if (childa.GetComponent<Rigidbody>() != null)
                {
                    childa.GetComponent<Rigidbody>().isKinematic = false;
                }
                foreach (Transform child0 in childa)
                {
                    if (child0.GetComponent<Rigidbody>() != null)
                    {
                        child0.GetComponent<Rigidbody>().isKinematic = false;
                    }
                    foreach (Transform child in child0)
                    {
                        if (child.GetComponent<Rigidbody>() != null)
                        {
                            child.GetComponent<Rigidbody>().isKinematic = false;
                        }
                        foreach (Transform child2 in child)
                        {
                            if (child2.GetComponent<Rigidbody>() != null)
                            {
                                child2.GetComponent<Rigidbody>().isKinematic = false;
                            }
                            foreach (Transform child3 in child2)
                            {
                                if (child3.GetComponent<Rigidbody>() != null)
                                {
                                    child3.GetComponent<Rigidbody>().isKinematic = false;
                                }
                            }
                        }
                    }
                }
            }

            //all AI disappear
            Destroy(AI);

            //animation
            Instantiate(explosion, bombA.transform.position, bombA.transform.rotation);
            Instantiate(explosion, bombB.transform.position, bombB.transform.rotation);
            Instantiate(explosion, bombC.transform.position, bombC.transform.rotation);
            Instantiate(explosion, bombD.transform.position, bombD.transform.rotation);
            Instantiate(explosion, bombE.transform.position, bombE.transform.rotation);

            bombA.active = false;
            bombB.active = false;
            bombC.active = false;
            bombD.active = false;
            bombE.active = false;

            light.GetComponent<Light>().enabled = false;

            Missions.missionCompleted = true;
        }
    }*/
}
