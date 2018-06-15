
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ManejadorContrucciones : MonoBehaviour {

    private int tipoObjetoAConstruir;


    public GameObject[] edificiosPrefabricados;
    public Camera mainCamera;
    public LayerMask layerWhereClick;

    private int rayDistance = 100000;
	// Use this for initialization
	void Start () {
        this.tipoObjetoAConstruir = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

        if(this.tipoObjetoAConstruir != 0) {
            if (Input.GetButtonDown("Fire1")){

                Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit info; // punto de choque con el rayo
                if (Physics.Raycast(ray, out info, this.rayDistance, this.layerWhereClick)) {

                    switch (this.tipoObjetoAConstruir)
                    {
                        case 1:
                            Instantiate(this.edificiosPrefabricados[0], info.point, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(this.edificiosPrefabricados[1], info.point, Quaternion.identity);
                            break;

                    }
                    this.tipoObjetoAConstruir = 0;

                }

               

            }
        }
		
	}

    public void seleccionObjetoEdificio(int tipoEdificio){

        this.tipoObjetoAConstruir= tipoEdificio;

    }
}
