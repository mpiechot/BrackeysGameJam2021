using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chrystal : MonoBehaviour
{

    [SerializeField] private UnityEvent<int> onGetHit; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetHit();
        Destroy(other.gameObject);
    }

    private void GetHit()
    {
        onGetHit?.Invoke(1);
    }

}
