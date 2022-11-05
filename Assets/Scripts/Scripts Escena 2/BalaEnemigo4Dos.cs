using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo4Dos : MonoBehaviour
{
    public float hit = 1;
    public float speed = 3.0f; //variable velocidad bala
    public Transform PuntoDisparo;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }


    private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<MakoNivel2>();
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
}
