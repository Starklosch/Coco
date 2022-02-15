using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, Interactable
{
    public static Checkpoint ActiveMortal, ActiveHell;

    [SerializeField]
    CheckpointType type;
    [SerializeField]
    bool makeDefault;

    public CheckpointType Type { get => type; }

    private void Awake()
    {
        if (!makeDefault)
            return;

        switch (type)
        {
            case CheckpointType.Mortal:
                if (ActiveMortal)
                {
                    Debug.LogWarning("Active checkpoint already set. May be there is another Checkpoint set to default");
                }
                ActiveMortal = this;
                break;
            case CheckpointType.Hell:
                if (ActiveHell)
                {
                    Debug.LogWarning("Active checkpoint already set. May be there is another Checkpoint set to default");
                }
                ActiveHell = this;
                break;
        }
    }

    public void OnPlayerFar(Transform player)
    {
    }

    public bool OnPlayerInteract(Transform player)
    {
        return false;
    }

    public void OnPlayerNear(Transform player)
    {
        // Replace checkpoint
        switch (type)
        {
            case CheckpointType.Mortal:
                if (ActiveMortal != null && ActiveMortal != this)
                    Destroy(ActiveMortal.gameObject);

                ActiveMortal = this;
                break;
            case CheckpointType.Hell:
                if (ActiveMortal != null && ActiveHell != this)
                    Destroy(ActiveHell.gameObject);

                ActiveHell = this;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        switch (type)
        {
            case CheckpointType.Mortal:
                Gizmos.color = Color.white;
                break;
            case CheckpointType.Hell:
                Gizmos.color = Color.magenta;
                break;
        }
        Gizmos.DrawSphere(transform.position, .5f);
    }

    public enum CheckpointType
    {
        Mortal,
        Hell
    }
}
