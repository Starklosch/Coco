using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour, Interactable
{

    [SerializeField] GameObject showInteraction;

    public void OnPlayerFar(Transform player)
    {
        showInteraction.SetActive(false);
    }

    public bool OnPlayerInteract(Transform player)
    {
        // Interaction

        Destroy(gameObject);

        return true;
    }

    public void OnPlayerNear(Transform player)
    {
        showInteraction.SetActive(true);
    }
}
