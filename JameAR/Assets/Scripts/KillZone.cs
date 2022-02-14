using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour, Interactable
{
    public void OnPlayerFar(Transform player)
    {
    }

    public bool OnPlayerInteract(Transform player) => false;

    public void OnPlayerNear(Transform player)
    {
        PlayerRespawn.Instance.Respawn();
    }
}
