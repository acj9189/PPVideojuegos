
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ManejadorCreacionUnidades : MonoBehaviour
{

    private int tipoUnidadACrear;


    public GameObject[] UnidadesGuerrerosPrefabricados;
    public Camera mainCamera;
    public LayerMask layerWhereClick;

    private int rayDistance = 100000;
    // Use this for initialization
    void Start()
    {
        //hh
        this.tipoUnidadACrear = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (this.tipoUnidadACrear != 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit info; // punto de choque con el rayo
                if (Physics.Raycast(ray, out info, this.rayDistance, this.layerWhereClick))
                {

                    switch (this.tipoUnidadACrear)
                    {
                        case 1:
                            Instantiate(this.UnidadesGuerrerosPrefabricados[0], info.point, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(this.UnidadesGuerrerosPrefabricados[1], info.point, Quaternion.identity);
                            break;

                    }
                    this.tipoUnidadACrear = 0;

                }



            }
        }

    }

    public void seleccionTipoUnidad(int tipoUnidad)
    {

        this.tipoUnidadACrear = tipoUnidad;

    }
}