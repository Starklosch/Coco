using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If player quits safe zone, he dies.
public class SafeZone : MonoBehaviour, Interactable
{
    public void OnPlayerFar(Transform player)
    {
        PlayerRespawn.Instance.Respawn();
    }

    public bool OnPlayerInteract(Transform player) => false;

    public void OnPlayerNear(Transform player)
    {
    }
}
