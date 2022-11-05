using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    //Movimiento
    public Transform player_pos;
    public float velocidad;
    public float distancia_frenado;
    public float distancia_regreso;
    //range
    public float range;
    private float distToPlayer;
    private bool canShoot;
    public float tiempoDisparoE;
    public GameObject LaBala;
    public Transform PuntoDisparo;
    private Rigidbody2D m_rig;
    //Vida enemigo
    public float PuntosVidaE;  //Conteo de vida
    public float VidaMaximaE = 2;  //Vida maxim


    [Header("Sonidos")]
    public GameObject[] SonidoEnemigoHerido;
/* 
    //Disparo
    public Transform punto_instancia;
    public GameObject bala;
   private float tiempo;  //tiempo transcurrido desde el ultimo disparo*/ 
    /*
   public float walkSpeed;
   [HideInInspector]
   public bool mustPatrol;
   public Rigidbody2D rb;
    */
    // Start is called before the first frame update
    void Start()
    {
         canShoot = true;
        player_pos = GameObject.Find("Personaje").transform; //accede a la posicion de Mako
        gameObject.GetComponent <Animator>().SetBool("enemyWalk", false);
    //  mustPatrol = true;
        //this.transform.localScale = new Vector2(-3,3);
         this.transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0); //QUITAR CUANDO SE ARREGLE EL SPRITE
        PuntosVidaE = VidaMaximaE;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player_pos.position);
        if (player_pos == null) { // cuando muere el personaje que deja de ejecutarse el codigo de seguimiento
         return;
        }
        //COMPORTAMIENTO ENEMIGO - MOVIMIENTO
        //Para separar funcionalidades, a medida que el codigo se hace muy extenso usa region
#region
 if(distToPlayer <= range)
 {
        if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado)
        {
        transform.position = Vector2.MoveTowards(transform.position, player_pos.position, velocidad*Time.deltaTime);// que traslade su posicion hacia Mako
        gameObject.GetComponent <Animator>().SetBool("enemyWalk", true);
        
         }
         if(Vector2.Distance(transform.position, player_pos.position)<distancia_regreso)
        {
        transform.position = Vector2.MoveTowards(transform.position, player_pos.position, -velocidad*Time.deltaTime);// que traslade su posicion hacia atras cuando Mako este muy cerca --- al restarle a velocidad, va hacia atras
        gameObject.GetComponent <Animator>().SetBool("enemyWalk", true);
        

         } 
         if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado && Vector2.Distance(transform.position, player_pos.position)<distancia_regreso)
        {
            
        transform.position = transform.position;// que se quede quieto entre la distancia de seguir a Mako y la de regreso cuando Mako esta muy cerca
        
       //
         }
          transform.position = transform.position;
             gameObject.GetComponent <Animator>().SetBool("enemyShoot", true);
           
            if(canShoot)
            {
               Shoot();
            }
    }else{
        
         
         gameObject.GetComponent <Animator>().SetBool("enemyShoot", false);
         gameObject.GetComponent <Animator>().SetBool("enemyWalk", false);
        }
#endregion
        //COMPORTAMIENTO ENEMIGO - MIRAR A MAKO
#region 
       //Flip
       if(player_pos.position.x>this.transform.position.x)
       {

            this.transform.eulerAngles = new Vector3 (0, 0, 0);

    } else {
 
            this.transform.eulerAngles = new Vector3 (0, 180, 0);
    }
          // this.transform.localScale = new Vector2(3,3); //cuando el enemigo esta hacia la derecha
          // this.transform.localScale = new Vector2(-3,3); //cuando esta hacia la izq 

#endregion


         //COMPORTAMIENTO ENEMIGO - DISPARAR A MAKO
         void Shoot()
    {
        //transform.position += transform.right * velBala * Time.deltaTime;
        tiempoDisparoE += Time.deltaTime;

        if (tiempoDisparoE >= 1)
    {
       GameObject prefab = Instantiate(LaBala, PuntoDisparo.position, transform.rotation) as GameObject;
        tiempoDisparoE = 0;

        Destroy(prefab, 2f);
        
        
    }
    }
/* #region 
        tiempo += Time.deltaTime;
        if(tiempo >= 2)
        {
           Instantiate(bala, punto_instancia.position, transform.rotation); //bala, posicion, rotacion
            tiempo = 0; //el tiempo se setea nuevamente en cero
        }
#endregion */
/* 
      if(mustPatrol)
      {
        Patrol();
      }
      */
    }
         //VIDA ENEMIGO
#region 
    public void TakeHit(float golpe)
    {
        PuntosVidaE -= golpe;
         gameObject.GetComponent <Animator>().SetTrigger("enemyHurt");
         NuevoSonido(SonidoEnemigoHerido[0], 1f);
        if(PuntosVidaE <= 0 )
        {

            Destroy(gameObject);
        }
    }
#endregion
    void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }
/*
    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
*/
}
