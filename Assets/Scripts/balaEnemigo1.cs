using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemigo1 : MonoBehaviour
{
    public float hit = 1;
public float speed = 3.0f; //variable velocidad bala
public Transform PuntoDisparo;
//la bala toca a otro enemigo

void Start()
    {
       
        //si la bala no colisiona, no importa, porque se destruye en dos segundos
    }
void Update(){ //solo necesitamos que se ejecute cuando se acciona
    transform.position += transform.right * Time.deltaTime * speed; //el objeto(bala) inicia hacia a la izquierda porque el enemigo aparece mirando hacia ahi
}
   private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerControler>();
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
   /*    void Destruir_()
    {
        Destroy(this.gameObject); //destruye el objeto de este script(la bala)
    }*/
 
}
