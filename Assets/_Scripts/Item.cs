using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Get()
    {
        Debug.Log("마차약탈 해버리기");
        Destroy(gameObject);
    }
}
