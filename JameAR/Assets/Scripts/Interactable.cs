using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Interactable
{
    void OnPlayerNear(Transform player);
    void OnPlayerFar(Transform player);
    bool OnPlayerInteract(Transform player);
}
