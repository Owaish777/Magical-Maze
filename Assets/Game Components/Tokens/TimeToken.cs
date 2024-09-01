using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToken : MonoBehaviour
{
    public Manager manager;
    public int value = 10;

    

    private void OnTriggerEnter(Collider other)
    {
        manager.reduceTime(value);
        Destroy(gameObject);
    }
}
