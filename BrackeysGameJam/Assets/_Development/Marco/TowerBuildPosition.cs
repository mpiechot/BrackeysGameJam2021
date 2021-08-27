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
    [SerializeField] private float lerpSpeed = 0.2f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (isSelected)
        {
            transform.GetChild(0).position = Vector3.Lerp(transform.GetChild(0).position, startPos + Vector3.up * .2f, lerpSpeed);
        }
        else
        {
            transform.GetChild(0).position = Vector3.Lerp(transform.GetChild(0).position, startPos, lerpSpeed);
        }
    }

    public void BuildTower(GameObject tower)
    {
        int cost = tower.GetComponent<Tower>().cost;
        if (this.tower == null && CoinManagement.GetInstance().OnCoinsReduced(cost))
        {
            this.tower = Instantiate(tower, transform.position, Quaternion.identity, this.transform.GetChild(0));
            this.tower.transform.localScale = Vector3.one * (1 / transform.parent.localScale.x);
            this.tower.SetActive(true);
        }    
    }

    public int SellTower()
    {
        if (tower != null)
        {
            int cost = tower.GetComponent<Tower>().cost;
            CoinManagement.GetInstance().OnCoinsCollected(cost);
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

    public void UnSelect()
    {
        print("Select!");
        isSelected = false;
    }
}
