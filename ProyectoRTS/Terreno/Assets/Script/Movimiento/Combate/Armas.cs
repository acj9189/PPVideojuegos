using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : MonoBehaviour {
	public int daño=10;
	public float tiempoRecarga = 0.5f;

	public Transform UbicacionDisparo;
	public GameObject FlechaPrefab;

	private float Tiempo;
	private Unidad unidad;

	public bool isRedy{ get; private set;}

	void Start ()
	{
		this.Tiempo=0;
		this.isRedy=true;

		this.unidad= GetComponent<Unidad>();
	}

	void Update(){
		if(this.isRedy){
			this.Tiempo = Time.deltaTime;
			if(this.Tiempo>this.tiempoRecarga){
				this.isRedy = true;
				this.Tiempo = 0;
			}
		}
	}

	public void dispara(){
		this.isRedy = false;
		GameObject p = Instantiate (
			this.FlechaPrefab,
			this.UbicacionDisparo.position,
			this.UbicacionDisparo.rotation
		);
	
		p.GetComponent<Proyectil>().arma = this;
	}

	public void OnProyectilCollision(Proyectil flecha,Unidad unidad){
		if(unidad.faccion != this.unidad.faccion){
			unidad.GetComponent<Salud> ().salud -= this.daño;
			Destroy (flecha);
		}	
	}
}
