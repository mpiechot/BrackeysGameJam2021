using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSetup : MonoBehaviour
{

    [SerializeField] private Transform moveGrid;

    private List<KlotzPathData> tileGrid;

    private void Start()
    {

        tileGrid = new List<KlotzPathData>();
        for (int i = 0; i < moveGrid.childCount; i++)
        {
            tileGrid.Add(moveGrid.GetChild(i).GetComponent<KlotzPathData>());
        }
    }

    internal KlotzPathData GetKlotz(Vector3 position)
    {
        float distance = float.MaxValue;
        KlotzPathData data = tileGrid[0];
        for (int i = 0; i < tileGrid.Count; i++)
        {
            if(Vector2.Distance(tileGrid[i].transform.position, position) < distance)
            {
                data = tileGrid[i];
                distance = Vector2.Distance(tileGrid[i].transform.position, position);
            }
        }

        return data;
    }
}
