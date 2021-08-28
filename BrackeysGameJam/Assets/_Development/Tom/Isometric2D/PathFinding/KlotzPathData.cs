using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KlotzType
{
    Path,
    Grass,
    Dirt,
    Flowers
}

public class KlotzPathData : MonoBehaviour
{

    private List<KlotzPathData> neighbours;
    [SerializeField] private LayerMask neighbourLayers;
    [SerializeField] private KlotzType type;
    public List<KlotzPathData> Neighbours { get => neighbours; }



    void Start()
    {
        neighbours = new List<KlotzPathData>();
        SetupNeighbours();
    }

    private void SetupNeighbours()
    {
        KlotzPathData nextNeighbour;
        if (nextNeighbour = LookForNeighbour(new Vector2(0.5f, 0.28f) * transform.parent.localScale))
        {
            neighbours.Add(nextNeighbour);
            //nextNeighbour.RegisterNeighbour(this);
        }
        if (nextNeighbour = LookForNeighbour(new Vector2(-0.5f, 0.28f) * transform.parent.localScale))
        {
            neighbours.Add(nextNeighbour);
            //nextNeighbour.RegisterNeighbour(this);
        }
        if (nextNeighbour = LookForNeighbour(new Vector2(0.5f, -0.28f) * transform.parent.localScale))
        {
            neighbours.Add(nextNeighbour);
            //nextNeighbour.RegisterNeighbour(this);
        }
        if (nextNeighbour = LookForNeighbour(new Vector2(-0.5f, -0.28f) * transform.parent.localScale))
        {
            neighbours.Add(nextNeighbour);
            //nextNeighbour.RegisterNeighbour(this);
        }
    }

    private KlotzPathData LookForNeighbour(Vector3 checkPosition)
    {
        Collider2D colliderCheck;
        if (colliderCheck = Physics2D.OverlapCircle(transform.position + checkPosition, 0.1f, neighbourLayers))
        {
            KlotzPathData klotzData;
            if (colliderCheck.TryGetComponent(out klotzData))
            {
                return klotzData;
            }
        }

        return null;
    }

    public void RegisterNeighbour(KlotzPathData newNeighbour)
    {
        if (neighbours == null) neighbours = new List<KlotzPathData>();
        if (!neighbours.Contains(newNeighbour))
        {
            neighbours.Add(newNeighbour);
        }
    }

    internal float GetCost(float[] moveMatrix)
    {
        if (moveMatrix.Length <= (int)type)
            return 10000;
        
        return moveMatrix[(int)type];
    }
}
