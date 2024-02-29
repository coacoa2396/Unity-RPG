using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreadableAdptor : MonoBehaviour, ITreadable
{
    public UnityEvent OnTreaded;
    

    public void Treaded()
    {
        OnTreaded?.Invoke();
    }
}
