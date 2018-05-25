using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour {
	public int maxSalud;

	private int currenthealt;
	public int salud{
		get{ return this.currenthealt;}
		set{ 
			this.currenthealt = value;
			this.currenthealt = Mathf.Clamp (this.currenthealt,0,this.maxSalud);

			if(this.currenthealt==0){
				Destroy (this.gameObject);
			}
		}
	}

	void Awake(){
		this.currenthealt = this.maxSalud;
	}
}
