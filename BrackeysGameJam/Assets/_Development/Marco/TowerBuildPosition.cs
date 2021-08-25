using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildPosition : MonoBehaviour
{
    [SerializeField] private GameObject towerMinionPrefab;
    [SerializeField] private int minionsPerTower = 4;
    
    private GameObject tower;
    private GameObject[] towerMinions;
    
    public void BuildTower(GameObject tower)
    {
        if (tower == null)
        {
            tower = Instantiate(tower, transform.position, Quaternion.identity, this.transform);
            towerMinions = new GameObject[minionsPerTower];
            for (int i = 0; i < minionsPerTower; i++)
            {
                towerMinions[i] = Instantiate(towerMinionPrefab, transform.position, Quaternion.identity, this.transform);
            }
        }    
    }

    public int SellTower()
    {
        if (tower != null)
        {
            int cost = tower.GetComponent<Tower>().cost;
            for (int i = 0; i < minionsPerTower; i++)
            {
                Destroy(towerMinions[i]);
            }
            Destroy(tower);
            return cost;
        }

        return 0;
    }
}
