using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TowerBuildPosition : MonoBehaviour
{
    [SerializeField] private GameObject towerMinionPrefab;
    [SerializeField] private int minionsPerTower = 4;
    
    private GameObject tower;
    private GameObject[] towerMinions;
    private bool isSelected = false;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void LateUpdate()
    {
        isSelected = false;
    }


    private void Update()
    {
        //Todo improve this!
        if (isSelected)
        {
            transform.position = Vector3.Lerp(transform.position, startPos + Vector3.up*.5f, 0.02f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, 0.02f);
        }
    }

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

    public void Select()
    {
        print("Select!");
        isSelected = true;
    }
}
