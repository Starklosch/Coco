using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretZone : MonoBehaviour, Interactable
{
    [SerializeField] GameObject target;

    private void Start()
    {
        target.SetActive(false);
    }

    public void OnPlayerFar(Transform player)
    {
        target.SetActive(false);
    }

    public bool OnPlayerInteract(Transform player)
    {
        return false;
    }

    public void OnPlayerNear(Transform player)
    {
        target.SetActive(true);
    }
}
