using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TowerBuildPosition : MonoBehaviour
{
    private GameObject tower;
    
    private bool isSelected = false;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
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
        print("Build!: " + tower);
        if (this.tower == null)
        {
            
           this.tower = Instantiate(tower, transform.position, Quaternion.identity, this.transform);
        }    
    }

    public int SellTower()
    {
        if (tower != null)
        {
            int cost = tower.GetComponent<Tower>().cost;
            Destroy(tower);
            tower.GetComponent<Tower>().Destroy();
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
