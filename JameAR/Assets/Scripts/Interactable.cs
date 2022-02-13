using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Interactable
{
    void OnPlayerNear();
    void OnPlayerFar();
    void OnPlayerInteract();
}
