using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxes : MonoBehaviour
{
    public float hit = 1;

    [Header("Sonidos")]
    public GameObject[] PeleaSonido;

     void OnTriggerEnter2D(Collider2D trig) {
    var player = trig.GetComponent<PlayerControler>();

       

        if (player ) { //&& trig.gameObject.tag == "golpes"
            player.golpeSuki (hit);
            Debug.Log("golpe");
           NuevoSonido(PeleaSonido[Random.Range(0, 3)], 1f);
            
        }

       
    }

    void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }
}
