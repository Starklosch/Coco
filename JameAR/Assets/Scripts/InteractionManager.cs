using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    Bounds bounds;
    [SerializeField]
    KeyCode ability = KeyCode.F;
    [SerializeField]
    bool isSoul;
    [SerializeField]
    GameObject aliveVersion, soulVersion;

    public bool IsSoul
    {
        get => isSoul;
    }

    static InteractionManager _instance;
    public static InteractionManager Instance
    {
        get => _instance;
    }

    List<Collider2D> _colliders = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        if (_instance)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var min = transform.position + bounds.min;
        var max = transform.position + bounds.max;
        var colliders = new List<Collider2D>(Physics2D.OverlapAreaAll(min, max, mask));
        var filteredColliders = new List<Collider2D>();
        //Interactable closestInteractable = null;

        if (colliders == null)
            return;

        // Process old colliders
        foreach (var col in _colliders)
        {
            if (col && !colliders.Contains(col) && col.TryGetComponent(out Interactable inter))
            {
                inter.OnPlayerFar(transform);
            }
        }

        // Process new colliders
        //float closestDistance = 0;
        foreach (var col in colliders)
        {
            if (col.TryGetComponent(out Interactable inter))
            {
                if (!_colliders.Contains(col))
                    inter.OnPlayerNear(transform);

                filteredColliders.Add(col);

                //var distance = Vector2.Distance(col.transform.position, transform.position);
                //if (closestInteractable == null || distance < closestDistance)
                //{
                //    closestInteractable = inter;
                //    closestDistance = distance;
                //}
            }
        }

        filteredColliders.Sort(DistanceComparer);

        if (Input.GetKeyDown(ability))
        {
            var handled = false;
            foreach (var item in filteredColliders)
            {
                handled = item.GetComponent<Interactable>().OnPlayerInteract(transform);
                if (handled)
                    break;
            }

            // World switch
            if (!handled)
            {
                isSoul = !isSoul;
                if (isSoul)
                {
                    aliveVersion.SetActive(false);
                    soulVersion.SetActive(true);
                }
                else
                {
                    soulVersion.SetActive(false);
                    aliveVersion.SetActive(true);
                }
            }
        }

        _colliders = filteredColliders;
    }

    int DistanceComparer(Component a, Component b)
    {
        var distanceA = Vector2.Distance(a.transform.position, transform.position);
        var distanceB = Vector2.Distance(b.transform.position, transform.position);

        if (distanceA == distanceB)
            return 0;

        if (distanceA > distanceB)
            return 1;

        return -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + bounds.center, bounds.size);
    }
}
