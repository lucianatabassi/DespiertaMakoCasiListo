using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3Dos : MonoBehaviour
{
      public Animator anim;
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

    //Deschipear
    public bool movimiento;
    //public bool disparando = true;
    //Vida enemigo
   // public float PuntosVidaE;  //Conteo de vida
    //public float VidaMaximaE = 2;  //Vida maxima
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
         movimiento = true;
           anim = GetComponent<Animator>();
        player_pos = GameObject.Find("Mako").transform; //accede a la posicion de Mako
        gameObject.GetComponent <Animator>().SetBool("caminar", false);
    //  mustPatrol = true;
        //this.transform.localScale = new Vector2(-3,3);
         //this.transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0); //QUITAR CUANDO SE ARREGLE EL SPRITE
        //PuntosVidaE = VidaMaximaE;
    }

    // Update is called once per frame
    void Update()
    {
         if( movimiento == true){
           Movimiento();
          }
        
            if(canShoot)
            {
               Shoot();
            }


    }
         void Movimiento()
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
        gameObject.GetComponent <Animator>().SetBool("caminar", true);
        
         }
         if(Vector2.Distance(transform.position, player_pos.position)<distancia_regreso)
        {
        transform.position = Vector2.MoveTowards(transform.position, player_pos.position, -velocidad*Time.deltaTime);// que traslade su posicion hacia atras cuando Mako este muy cerca --- al restarle a velocidad, va hacia atras
        gameObject.GetComponent <Animator>().SetBool("caminar", true);
        

         } 
         if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado && Vector2.Distance(transform.position, player_pos.position)<distancia_regreso)
        {
            
        transform.position = transform.position;// que se quede quieto entre la distancia de seguir a Mako y la de regreso cuando Mako esta muy cerca
        
       //
         }
          transform.position = transform.position;
             
           

    }else{
        
         
         gameObject.GetComponent <Animator>().SetBool("disparar", false);
         gameObject.GetComponent <Animator>().SetBool("caminar", false);
       
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
     }


         //COMPORTAMIENTO ENEMIGO - DISPARAR A MAKO
         void Shoot()
    {
        gameObject.GetComponent <Animator>().SetBool("disparar", true);
        //transform.position += transform.right * velBala * Time.deltaTime;
        tiempoDisparoE += Time.deltaTime;

        if (tiempoDisparoE >= 2)
    {
       GameObject prefab = Instantiate(LaBala, PuntoDisparo.position, transform.rotation) as GameObject;
        tiempoDisparoE = 0;

        Destroy(prefab, 2f);
        
        
    }
    }

    void OnTriggerEnter2D (Collider2D collision) {

        if (collision.transform.tag =="aparato" ) {
            TemblorCamara.Instance.MoverCamara(3, 5, 0.8f);
            anim.SetTrigger("deschipeado");
            movimiento =false;
            canShoot = false; 
            velocidad= 0 ;
            anim.SetBool("caminar", false);
            anim.SetBool("disparar", false);
            anim.SetBool("deschipeadoIdle", true);
            Destroy(gameObject, 5f);
        
         }
        }
}
