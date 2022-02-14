using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, SoulPower
{

    public bool Powered => powered;

    [SerializeField]
    bool powered;
    [SerializeField]
    Transform movable;
    [SerializeField]
    Vector2 startRelative, endRelative;
    [SerializeField]
    float speed;

    Coroutine moveCorutine;
    float savedState = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!movable && transform.childCount > 0)
            movable = transform.GetChild(0);

        //if (speed <= 0)
            //Debug.LogWarning("Time is 0!");
    }

    // Update is called once per frame
    void Update()
    {
        if (powered && moveCorutine == null)
            moveCorutine = StartCoroutine(Movement());
        else if (!powered && moveCorutine != null)
            StopCoroutine(moveCorutine);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        var start = (Vector2)transform.position + startRelative;
        var end = (Vector2)transform.position + endRelative;

        Gizmos.DrawSphere(start, .2f);
        Gizmos.DrawSphere(end, .2f);
        Gizmos.DrawLine(start, end);
    }

    IEnumerator Movement()
    {
        savedState %= 2 * speed;
        if (float.IsNaN(savedState))
            savedState = 0;

        var start = (Vector2)transform.position + startRelative;
        var end = (Vector2)transform.position + endRelative;

        for (float i = savedState; true; i += Time.deltaTime)
        {
            var pong = Mathf.PingPong(i * speed, 1);
            movable.position = Vector2.Lerp(start, end, pong);

            savedState = i;
            yield return null;
        }
    }

    public void OnSoulCollected()
    {
        powered = true;
    }
}
