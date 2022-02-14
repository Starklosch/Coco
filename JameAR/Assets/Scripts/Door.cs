using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, SoulPower
{
    [SerializeField]
    bool open = false;

    [SerializeField]
    GameObject openDoor;
    GameObject closedDoor;

    public bool Open { get => open; set => open = value; }

    void Start()
    {
        open = false;
    }

    void Update()
    {
        if (open)
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
        else
        {
            openDoor.SetActive(false);
            closedDoor.SetActive(true);
        }
    }

    public void OnSoulCollected()
    {
        open = true;
    }
}
