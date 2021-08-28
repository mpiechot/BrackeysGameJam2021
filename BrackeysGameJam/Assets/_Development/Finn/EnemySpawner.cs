using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPref;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] float spawnPositionRandomFactor;
    [SerializeField] float recoveryTime;
    [SerializeField] private LifeCycleManager lifeCycleManager;
    [SerializeField] private float waveFactor;
    [SerializeField] private float baseEnemyNum;


    private CoinManagement coinManager;

    public void SetEnemy(GameObject enemy)
    {
        enemyPref = enemy;
    }

    void Start()
    {
        //alle Gegner besiegt Event mit StartNextWave abonnieren \\
        coinManager = CoinManagement.GetInstance();
    }
    

    public void StartNextWave(int waveCounter)
    {
        StartCoroutine(WaitForRecoveryTime(waveCounter));
    }

    private IEnumerator SpawnEnemies(int waveNR)
    {
        //Debug.Log("Neue Gegner werden erschaffen.");
        //print(WaveFunction(waveNR));
        for (int i = 0; i < WaveFunction(waveNR); i++)
        {
            GameObject enemy = Instantiate<GameObject>(enemyPref,
                RandomSpawnOffset()
                , Quaternion.identity) ;
            enemy.SetActive(true);
            enemy.GetComponent<ISOEnemy>().EnemyDiedEvent.AddListener(coinManager.OnCoinsCollected);
            lifeCycleManager.RegisterEnemy(enemy.GetComponent<ISOEnemy>());
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private int WaveFunction(int waveNR)
    {
        return Mathf.FloorToInt(waveNR * waveFactor + baseEnemyNum);
    }

    private Vector3 RandomSpawnOffset()
    {
        return new Vector3(spawnPoint.position.x + Random.Range(-spawnPositionRandomFactor, spawnPositionRandomFactor), spawnPoint.position.y + Random.Range(-spawnPositionRandomFactor, spawnPositionRandomFactor));
    }

    IEnumerator WaitForRecoveryTime(int waveNR)
    {
        //Debug.Log("Erholungszeit beginnt.");
        yield return new WaitForSeconds(recoveryTime);
        yield return StartCoroutine(SpawnEnemies(waveNR));

        //// #######################################
        //// This is an Endless Mode!! Remove this
        //yield return new WaitForSeconds(recoveryTime);
        //StartCoroutine("WaitForRecoveryTime");
        //// Until here
        //// ######################################

    }
}
