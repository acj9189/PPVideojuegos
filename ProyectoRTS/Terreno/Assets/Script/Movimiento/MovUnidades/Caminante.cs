using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Caminante : MovTester {

    private NavMeshAgent agente;

    // Use this for initialization
    public override void Init () {
        this.agente = GetComponent<NavMeshAgent>();
	}

    public override void OrdenMov(Vector3 MundoPos)
    {
		Debug.Log(this.agente.SetDestination(MundoPos));
    }


}
