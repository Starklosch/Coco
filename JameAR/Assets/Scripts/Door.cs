using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, SoulPower
{
    [SerializeField]
    bool open = false;

    [SerializeField]
    GameObject openDoor;
    [SerializeField]
    GameObject closedDoor;
    [SerializeField]
    Collider2D col;

    public bool Open { get => open; set => open = value; }

    void Start()
    {
        open = false;
        if (!col)
            col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (open)
        {
            if (closedDoor != null)
                closedDoor.SetActive(false);
            if (openDoor != null)
                openDoor.SetActive(true);

            col.enabled = false;
        }
        else
        {
            if (openDoor != null)
                openDoor.SetActive(false);
            if (closedDoor != null)
                closedDoor.SetActive(true);

            col.enabled = true;
        }
    }

    public void OnSoulCollected()
    {
        open = true;
    }
}
