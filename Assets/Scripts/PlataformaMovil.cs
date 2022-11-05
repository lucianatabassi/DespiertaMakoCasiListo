using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject objetoAmover;
    public Transform PuntoPartida;
    public Transform PuntoFin;
    public float velPlataforma;
    private Vector3 MoverHacia;

    void Start()
    {
        MoverHacia = PuntoFin.position; //cuando se ejecute otra vez, q se mueva hacia el punto final
    }

    
    void Update()
    {
        objetoAmover.transform.position = Vector3.MoveTowards(objetoAmover.transform.position, MoverHacia, velPlataforma * Time.deltaTime);

        if (objetoAmover.transform.position == PuntoFin.position) { //si llega al punto final  que vuelva hacia el punto de partida
            MoverHacia = PuntoPartida.position;
        }

        if (objetoAmover.transform.position == PuntoPartida.position) { //si llega al punto inicial  que vuelva hacia el punto final
            MoverHacia = PuntoFin.position;
        }
    }
}
