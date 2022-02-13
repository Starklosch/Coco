using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour, Interactable
{

    [SerializeField] GameObject showInteraction;

    public void OnPlayerFar()
    {
        showInteraction.SetActive(false);
    }

    public void OnPlayerInteract()
    {
        // Interaction

        Destroy(gameObject);
    }

    public void OnPlayerNear()
    {
        showInteraction.SetActive(true);
    }
}
