using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private PathSetup setup;

    [SerializeField] private GameObject debugTile;
    [SerializeField] private GameObject pathTile;

    Dictionary<KlotzPathData, float> gScore;
    Dictionary<KlotzPathData, float> fScore;

    public List<KlotzPathData> StartPathfinding(Transform startPosition, Transform endPosition, float[] moveMatrix)
    {
        return FindPath(startPosition.position, endPosition.position, moveMatrix);
    }

    public List<KlotzPathData> StartPathfinding(Transform startPosition, Vector3 endPosition, float[] moveMatrix)
    {
        return FindPath(startPosition.position, endPosition, moveMatrix);
    }
    public List<KlotzPathData> StartPathfinding(Vector3 startPosition, Vector3 endPosition, float[] moveMatrix)
    {
        return FindPath(startPosition, endPosition, moveMatrix);
    }
    public List<KlotzPathData> StartPathfinding(Vector3 startPosition, Transform endPosition, float[] moveMatrix)
    {
        return FindPath(startPosition, endPosition.position, moveMatrix);
    }

    private List<KlotzPathData> FindPath(Vector3 startPosition, Vector3 endPosition, float[] moveMatrix)
    {
        KlotzPathData startKlotz = setup.GetKlotz(startPosition);
        KlotzPathData endKlotz = setup.GetKlotz(endPosition);

        KlotzPathData currentKlotz = startKlotz;
        Dictionary<KlotzPathData, KlotzPathData> cameFromKlotz = new Dictionary<KlotzPathData, KlotzPathData>();

        List<KlotzPathData> openSet = new List<KlotzPathData>();
        List<KlotzPathData> closedSet = new List<KlotzPathData>();

        openSet.Add(startKlotz);
        gScore = new Dictionary<KlotzPathData, float>();
        fScore = new Dictionary<KlotzPathData, float>();

        gScore.Add(startKlotz, 0);
        fScore.Add(startKlotz, HValue(startKlotz.transform.position, endKlotz.transform.position));

        int saveNum = 1000;

        while(openSet.Count > 0)
        {
            saveNum--;
            if (saveNum < 0)
            {
                print("Faliure due to safety.");
                return null;
            }

            // Get lowest f valued tile
            currentKlotz = FindNextOpenTile(openSet, fScore);

            if (currentKlotz == endKlotz)
            {
                // Last Tile was found
                return SetupPath(currentKlotz, cameFromKlotz);
            }

            openSet.Remove(currentKlotz);
            closedSet.Add(currentKlotz);
            
            // Update Segments of path finding (g, f, ...)
            foreach(KlotzPathData nKlotz in currentKlotz.Neighbours)
            {
                float tentative_g = gScore[currentKlotz] + MoveCost(currentKlotz, nKlotz, moveMatrix);
                if(!gScore.ContainsKey(nKlotz) || tentative_g < gScore[nKlotz])
                {
                    // Update Neighbour 
                    if (cameFromKlotz.ContainsKey(nKlotz))
                        cameFromKlotz[nKlotz] = currentKlotz;
                    else
                        cameFromKlotz.Add(nKlotz, currentKlotz);

                    // Update neighbour g
                    if (gScore.ContainsKey(nKlotz))
                        gScore[nKlotz] = tentative_g;
                    else
                        gScore.Add(nKlotz, tentative_g);

                    // Update neighbour f
                    if (fScore.ContainsKey(nKlotz))
                        fScore[nKlotz] = gScore[nKlotz] + HValue(nKlotz.transform.position, endKlotz.transform.position);
                    else
                        fScore.Add(nKlotz, gScore[nKlotz] + HValue(nKlotz.transform.position, endKlotz.transform.position));

                    if (!openSet.Contains(nKlotz) && !closedSet.Contains(nKlotz))
                        openSet.Add(nKlotz);

                }
            }
            //print("Step!");
            //Instantiate(debugTile, currentKlotz.transform.position, Quaternion.identity).SetActive(true);
            //yield return null;

        }

        // Here no goal was found
        print("Done pathfinding!");
        return null;
    }

    
    private float MoveCost(KlotzPathData currentKlotz, KlotzPathData nKlotz, float[] moveMatrix)
    {
        // For now all cost is the same
        return nKlotz.GetCost(moveMatrix);
    }

    private KlotzPathData FindNextOpenTile(List<KlotzPathData> openSet, Dictionary<KlotzPathData, float> fScore)
    {
        float f = float.MaxValue;
        int selection = 0;
        for(int i = 0; i < openSet.Count; i++)
        {
            if (fScore.ContainsKey(openSet[i]) && fScore[openSet[i]] < f)
            {
                f = fScore[openSet[i]];
                selection = i;
            }
        }
        return openSet[selection];
    }

    private float HValue(Vector2 from, Vector2 goal)
    {
        return Vector2.Distance(from, goal);
    }



    private List<KlotzPathData> SetupPath(KlotzPathData currentKlotz, Dictionary<KlotzPathData, KlotzPathData> cameFromKlotz)
    {
        print("Path found!");
        List<KlotzPathData> path = new List<KlotzPathData>();
        path.Add(currentKlotz);
        while (cameFromKlotz.ContainsKey(currentKlotz))
        {
            //Instantiate(pathTile, currentKlotz.transform.position, Quaternion.identity).SetActive(true);
            currentKlotz = cameFromKlotz[currentKlotz];
            path.Add(currentKlotz);
        }
        path.Reverse();

        return path;
    }


}
