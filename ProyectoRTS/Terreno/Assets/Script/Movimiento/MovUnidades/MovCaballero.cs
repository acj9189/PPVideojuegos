using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovCaballero : MovTester {

	private NavMeshAgent agente;

	//deteccion de esnemigos
	private MovTester ActualEnemigo;
	public float MaxdistanciaCombate;
	public LayerMask Capa;

	private float tiempo;
	private float tiempoSalida;
	// Use this for initialization
	public override void Init () {
		this.agente = GetComponent<NavMeshAgent>();
		this.MaxdistanciaCombate = 100;
		this.tiempoSalida = 1f;
	}

	public override void OrdenMov(Vector3 MundoPos)
	{
		this.agente.SetDestination(MundoPos);
	}

	public void CheckSurrounding(){

		Collider[] UnidadesCercanas=Physics.OverlapSphere(
			this.transform.position,
			this.MaxdistanciaCombate,
			this.Capa
		);

		for (int i = 0; i < UnidadesCercanas.Length; i++) {
			if (UnidadesCercanas [i].gameObject != this.gameObject) {
				MovTester posibleEnemigo = UnidadesCercanas [i].GetComponent<MovTester> ();
				if(posibleEnemigo!=null){
					if (posibleEnemigo.faccion != this.faccion) {
						this.ActualEnemigo = posibleEnemigo;
						Debug.Log ("Enemigo de Caballero "+name);
						break;
					}
				}
			}
		}
	}

	void Update(){
	/*	this.tiempo += Time.deltaTime;
		if (this.tiempo > this.tiempoSalida) {
			this.tiempo = 0;
			if (this.ActualEnemigo == null) {
				this.CheckSurrounding ();
			} else {
				Debug.Log (this.ActualEnemigo.name);
			}
		}*/
	}
}
