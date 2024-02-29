using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAdaptor : MonoBehaviour, IInteractable
{
    public UnityEvent<PlayerInteractor> OnInteracted;

    public void Interact(PlayerInteractor player)
    {
        OnInteracted?.Invoke(player);
    }
}
