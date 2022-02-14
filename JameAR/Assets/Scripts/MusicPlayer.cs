using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip startPart, loopPart;

    private void Start()
    {
        if (source)
            source = GetComponent<AudioSource>();

        if (!startPart || !loopPart)
            Debug.LogWarning("Sound clip not selected");

        source.clip = startPart;
        source.Play();
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.loop = true;
            source.clip = loopPart;
            source.Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .3f);
    }
}
