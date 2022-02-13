using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteraction : MonoBehaviour, Interactable
{
    public void OnPlayerNear(Transform player)
    {
        player.SetParent(transform, true);
    }

    public void OnPlayerFar(Transform player)
    {
        player.SetParent(null, true);
    }

    public bool OnPlayerInteract(Transform player)
    {
        return false;
    }
}
