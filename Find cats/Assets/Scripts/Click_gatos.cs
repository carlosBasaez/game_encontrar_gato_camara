using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_gatos : MonoBehaviour
{
    int Cantidad_gatos = 2;
    int Gatos_atrapados = 0;

    public CapsuleCollider elgato;
    public GameObject activar_mensaje;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //ocupar distintos tags para desactivar gatos
                if (hitInfo.collider.gameObject.tag == "Gato_juan")
                {
                    Gatos_atrapados++;
                    Debug.Log(Gatos_atrapados);
                    elgato.enabled = false;
                    if (Cantidad_gatos == Gatos_atrapados)
                    {
                        activar_mensaje.SetActive(true);
                        Gatos_atrapados = 0;
                    }
                    
                }
   
            }
        }
    }

}
