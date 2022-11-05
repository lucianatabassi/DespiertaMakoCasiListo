using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoEnemigo1 : MonoBehaviour
{
    //este script acciona la bala
    public GameObject LaBala;
    public Transform PuntoDisparo;

    public float tiempoDisparoE;
    // Update is called once per frame
    void Update()
    {
        tiempoDisparoE += Time.deltaTime;

        if (tiempoDisparoE >= 2)
    {
       GameObject prefab = Instantiate(LaBala, PuntoDisparo.position, transform.rotation) as GameObject;
        tiempoDisparoE = 0;

        Destroy(prefab, 2f);
        
        
    }
    }
}
