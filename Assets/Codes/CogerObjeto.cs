using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SistemaAgarre : MonoBehaviour
{
    public float alcance = 1f;
    private GameObject[] objetosAgarrados;

    //***********************************
    //Instancia del socket para escuchar los gestos
    readSocket socket = new readSocket();
    // Start is called before the first frame update
    //Gesto reconocido
    String gesto = "";

    //***************************************

      void Start()
    {
    
    }

    void Update()
    {
        try{
            gesto = socket.Update();
              if (Input.GetKeyDown(KeyCode.E) || gesto == "Up")
        {
            AgarrarObjetos();
        }

        if (Input.GetKeyDown(KeyCode.R) || gesto == "Forword")
        {
            SoltarObjetos();
        }
        }catch (Exception ex)
        {
            socket.Start();
        }
      
    }

    void AgarrarObjetos()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, alcance);
        objetosAgarrados = new GameObject[colliders.Length];

        int i = 0;
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Objeto"))
            {
                collider.GetComponent<Rigidbody>().isKinematic = true;
                collider.transform.SetParent(transform);
                objetosAgarrados[i] = collider.gameObject;
                i++;
            }
        }
    }

    void SoltarObjetos()
    {
        if (objetosAgarrados != null)
        {
            foreach (var objeto in objetosAgarrados)
            {
                if (objeto != null)
                {
                    objeto.GetComponent<Rigidbody>().isKinematic = true;
                    objeto.transform.SetParent(null);
                }
            }
            objetosAgarrados = null;
        }
    }
}
