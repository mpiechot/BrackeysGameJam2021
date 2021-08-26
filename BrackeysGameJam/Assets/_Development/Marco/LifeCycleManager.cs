using UnityEngine;
using UnityEngine.Events;

public class LifeCycleManager : MonoBehaviour
{
    public UnityEvent GameOverEvent = new UnityEvent();
    
    public void OnLifeChange(int newHealth)
    {
        if (newHealth <= 0)
        {
            GameOverEvent.Invoke();
        }
    }
}