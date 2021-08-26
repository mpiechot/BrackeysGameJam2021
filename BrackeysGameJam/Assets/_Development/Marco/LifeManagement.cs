using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManagement : MonoBehaviour
{
    [SerializeField] private int health = 40;
    
    public UnityEvent<int> LifeChangedEvent = new UnityEvent<int>();
    
    public void OnHealthReduced(int ammount)
    {
        health -= ammount;
        LifeChangedEvent.Invoke(health);
    }
}
