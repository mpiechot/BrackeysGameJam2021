using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile
{
    public Vector2 position;
    public List<PathTile> neighbours;
    public float heuristics;
}
