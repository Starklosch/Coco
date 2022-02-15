using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour, Interactable
{

    [SerializeField] GameObject showInteraction;
    [SerializeField] GameObject target;
    [SerializeField] Sprite dotSprite;
    [SerializeField] float time;

    SoulPower soulPower;
    SpriteRenderer spRen;
    bool triggered = false;

    private void Start()
    {
        showInteraction.SetActive(false);

        soulPower = target.GetComponent<SoulPower>();
        if (!target || soulPower == null)
            Debug.LogWarning("Unrecognized soul power");

        spRen = GetComponent<SpriteRenderer>();
    }

    public void OnPlayerFar(Transform player)
    {
        showInteraction.SetActive(false);
    }

    public bool OnPlayerInteract(Transform player)
    {
        if (triggered)
            return false;

        triggered = true;

        if (soulPower != null)
            StartCoroutine(Animation());

        return true;
    }

    public void OnPlayerNear(Transform player)
    {
        showInteraction.SetActive(true);
    }

    IEnumerator Animation()
    {
        var startPos = transform.position;
        var startScale = transform.localScale;
        var endScale = Vector2.one * .5f;
        spRen.sprite = dotSprite;

        for (float i = 0; i < time; i += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(startPos, target.transform.position, i / time);
            transform.localScale = Vector2.Lerp(startScale, endScale, i / time);
            yield return null;
        }

        transform.position = target.transform.position;

        spRen.enabled = false;

        yield return new WaitForSeconds(0.1f);

        soulPower.OnSoulCollected();
        Destroy(gameObject);
    }
}
