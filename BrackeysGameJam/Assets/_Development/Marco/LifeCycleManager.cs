using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeCycleManager : MonoBehaviour
{
    
    public UnityEvent GameOverEvent = new UnityEvent();

    [SerializeField] private int totalWaves;
    [SerializeField] private UnityEvent<int> onNextWave;
    [SerializeField] private UnityEvent gameWonEvent;

    private List<ISOEnemy> registeredEnemies;
    private int currentWave;

    private void Start()
    {
        OnNextWave();
    }

    public void OnLifeChange(int newHealth)
    {
        if (newHealth <= 0)
        {
            GameOverEvent.Invoke();
        }
    }


    public void RegisterEnemy(ISOEnemy enemyToRegister)
    {
        if (registeredEnemies == null) registeredEnemies = new List<ISOEnemy>();
        registeredEnemies.Add(enemyToRegister);
    }

    public void UnRegisterEnemy(ISOEnemy enemy)
    {
        if (registeredEnemies != null)
        {
            registeredEnemies.Remove(enemy);
            if (registeredEnemies.Count <= 0)
            {
                OnNextWave();
            }
        }
    }

    private void OnNextWave()
    {
        if(currentWave < totalWaves)
        {
            System.Array.ForEach(FindObjectsOfType<EnemySpawner>(), spawner => spawner.StartNextWave(currentWave));
            currentWave++;
            onNextWave?.Invoke(currentWave);
        }
        else
        {
            // Game Won
            gameWonEvent?.Invoke();
        }
    }
}