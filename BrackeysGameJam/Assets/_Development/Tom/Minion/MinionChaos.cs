using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionChaos : MonoBehaviour
{
    private MinionVars vars;

    private void Start()
    {
        vars = GetComponent<MinionVars>();
    }

    public void AddChaos(int numEnemies)
    {
        vars.AddChaos(Time.fixedDeltaTime * numEnemies);
    }



}
