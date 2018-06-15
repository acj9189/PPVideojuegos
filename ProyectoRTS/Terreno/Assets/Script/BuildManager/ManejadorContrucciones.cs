
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ManejadorContrucciones : MonoBehaviour {

    private int tipoObjeyo;


    public GameObject[] edificiosPrefabricados;
    public Camera mainCamera;
    public LayerMask layerWhereClick;
	// Use this for initialization
	void Start () {
        this.tipoObjeyo = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

        if(this.tipoObjeyo != 0) {
            if (Input.GetButtonDown("Fire1")){

                Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);

                switch (this.tipoObjeyo)
                {
                    case 1:
                        break;
                    case 2:
                        break;

                }
                this.tipoObjeyo = 0;

            }
        }
		
	}

    public void seleccionObjetoEdificio(int tipoEdificio)
    {

    }
}
