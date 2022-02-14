using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour, Interactable
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    bool loop = false;

    private void Start()
    {
        if (source)
            source = GetComponent<AudioSource>();

        if (!source.clip)
            Debug.LogWarning("Sound clip not selected");
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
        source.loop = loop;
        source.Play();
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, .3f);
    }
}
