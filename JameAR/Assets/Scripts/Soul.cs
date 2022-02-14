using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour, Interactable
{

    [SerializeField] GameObject showInteraction;
    [SerializeField] GameObject target;

    SoulPower soulPower;

    private void Start()
    {
        showInteraction.SetActive(false);

        soulPower = target.GetComponent<SoulPower>();
        if (!target || soulPower == null)
            Debug.LogWarning("Unrecognized soul power");
    }

    public void OnPlayerFar(Transform player)
    {
        showInteraction.SetActive(false);
    }

    public bool OnPlayerInteract(Transform player)
    {
        // Interaction
        if (soulPower != null)
            soulPower.OnSoulCollected();

        Destroy(gameObject);

        return true;
    }

    public void OnPlayerNear(Transform player)
    {
        showInteraction.SetActive(true);
    }
}
