using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] float spawnPositionRandomFactor;
    [SerializeField] float recoveryTime;
    private Transform spawnPointEnemy;

    private int waveCouter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //alle Gegner besiegt Event mit StartNextWave abonnieren \\


        spawnPointEnemy = transform;

        StartNextWave();
        
    }
    

    public void StartNextWave()
    {
        waveCouter++;
        StartCoroutine("WaitForRecoveryTime");
    }

    private void SpawnEnemies(int waveNR)
    {
        Debug.Log("Neue Gegner werden erschaffen.");
        for (int i = 0; i < waveCouter*2; i++)
        {
            spawnPointEnemy.position = new Vector3(spawnPoint.position.x + Random.Range(-spawnPositionRandomFactor, spawnPositionRandomFactor), 0.37f, spawnPoint.position.z+ Random.Range(-spawnPositionRandomFactor, spawnPositionRandomFactor));
            Instantiate<GameObject>(enemy, spawnPointEnemy.position, Quaternion.identity);
        }
        
    }

    IEnumerator WaitForRecoveryTime()
    {
        Debug.Log("Erholungszeit beginnt.");
        yield return new WaitForSeconds(recoveryTime);
        SpawnEnemies(waveCouter);
    }
}
