using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemigo3 : MonoBehaviour
{
public float hit = 1;
public float speed = 3.0f; //variable velocidad bala
public Transform ShootPos;
//la bala toca a otro enemigo

void Start()
    {
       
        //si la bala no colisiona, no importa, porque se destruye en dos segundos
    }
void Update(){ //solo necesitamos que se ejecute cuando se acciona
// transform.position += transform.right *  speed * Time.deltaTime ; //el objeto(bala) inicia hacia a la izquierda porque el enemigo aparece mirando hacia ahi
     transform.position += transform.right * Time.deltaTime * speed;
}
   private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerControler>();
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
/*     public float dieTime;
    public float damage;
    public float hit = 1;
    public float speed = 3.0f; 
    public Transform ShootPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }
void Update(){ //solo necesitamos que se ejecute cuando se acciona
    transform.position += transform.right * Time.deltaTime * speed; //el objeto(bala) inicia hacia a la izquierda porque el enemigo aparece mirando hacia ahi
}
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
                var player = col.collider.GetComponent<PlayerControler>();
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    void Die()
    {
        Destroy(gameObject);
    } */
}
