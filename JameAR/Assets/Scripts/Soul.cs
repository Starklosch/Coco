using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour, Interactable
{

    [SerializeField] GameObject showInteraction;
    [SerializeField] SoulPower target;

    private void Start()
    {
        showInteraction.SetActive(false);
    }

    public void OnPlayerFar(Transform player)
    {
        showInteraction.SetActive(false);
    }

    public bool OnPlayerInteract(Transform player)
    {
        // Interaction
        if (target != null)
            target.OnSoulCollected();

        Destroy(gameObject);

        return true;
    }

    public void OnPlayerNear(Transform player)
    {
        showInteraction.SetActive(true);
    }
}
