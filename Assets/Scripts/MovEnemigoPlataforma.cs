using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigoPlataforma : MonoBehaviour
{
    //Vida
    public float PuntosVidaE;  //Conteo de vida
    public float VidaMaximaE = 2;  //Vida maxima

    public float range;
    //public float timeBTWShots;
    public float shootSpeed;
    private bool canShoot;
    //VIDEO 2
    //Mov sobre plataforma
    private Rigidbody2D m_rig;
    public float speed;
    //public float velBala = 4;
    public GameObject bullet;
    //public balaEnemigo3 bullet;
    public Transform Personaje;
    public Transform ShootPos;
    private float distToPlayer;
public float tiempoDisparoE;

    [Header("Sonidos")]
    public GameObject[] SonidoEnemigoHerido;
    void Start(){
        m_rig = GetComponent<Rigidbody2D>();
        canShoot = true;
        PuntosVidaE = VidaMaximaE;
    }

    void Update()
    {
               //transform.position += transform.right *velBala* Time.deltaTime;

        m_rig.velocity = new Vector2(speed,m_rig.velocity.y);
        gameObject.GetComponent <Animator>().SetBool("enemyWalk", true);
        
        distToPlayer = Vector2.Distance(transform.position, Personaje.position);
       

        if(distToPlayer <= range)
        {
            if(Personaje.position.x > transform.position.x && transform.localScale.x < 0 || Personaje.position.x < transform.position.x && transform.localScale.x > 0 )
            {
              //Flip();
              speed *= -1;
              this.transform.localScale = new Vector2(this.transform.localScale.x * -1,this.transform.localScale.y);
              //bullet.transform.localScale = new Vector2(bullet.transform.localScale.x * -1,bullet.transform.localScale.y);
            //transform.position += transform.right *velBala* Time.deltaTime;
           
            }
            gameObject.GetComponent <Animator>().SetBool("enemyShoot", true);
            m_rig.velocity = Vector2.zero;
            if(canShoot)
            {
               Shoot();
            }
            
            
/* 
         if(canShoot){
              StartCoroutine(Shoot());
            }  */
          
        }else{
        
         m_rig.velocity = new Vector2(speed,m_rig.velocity.y);
         gameObject.GetComponent <Animator>().SetBool("enemyShoot", false);
        gameObject.GetComponent <Animator>().SetBool("enemyWalk", true);
        }
    }
    private void Shoot()
    {
        

        //transform.position += transform.right * velBala * Time.deltaTime;
        tiempoDisparoE += Time.deltaTime;

        if (tiempoDisparoE >= 0.5)
        
    {
        GameObject prefab = Instantiate(bullet, ShootPos.position, transform.rotation) as GameObject;
        tiempoDisparoE = 0;
       Destroy(prefab, 2f);
        if(this.transform.localScale.x <0)
        {
        //Instantiate(bullet, ShootPos.position, transform.rotation);
       
       prefab.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0); //rotacion
       
        }
        else if(this.transform.localScale.x >0)
        {
       
       prefab.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);//rotacion

        }

        
    }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="platform")
        {
            speed *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x * -1,this.transform.localScale.y);
        }
    }
    
         //VIDA ENEMIGO
#region 
    public void TakeHit(float golpe)
    {
        PuntosVidaE -= golpe;
        
        NuevoSonido(SonidoEnemigoHerido[0], 1f);
        gameObject.GetComponent <Animator>().SetBool("enemigoHerido", true);
        //gameObject.GetComponent <Animator>().SetTrigger("enemigoHerido");
        if(PuntosVidaE <= 0 )
        {
            Destroy(gameObject);
        }
    }
#endregion
    void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }
}
/*     [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;
    private Rigidbody2D rb;
     Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if(informacionSuelo == false)
        {
            //Girar
            Girar();
        }
    }
    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);

    } 
}
*/

     //Video 3
 //   public float WalkSpeed;
    /* public float distancia; */
   /*
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public Transform controladorSuelo;
    public LayerMask groundLayer;
    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
       /*  RaycastHit2D groundInfo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        if(groundInfo.collider == false)
        {
            Flip();
        } */
    //}
    /*
    private void FixedUpdate()
    {
        if(mustPatrol == true)
        {
            mustTurn = !Physics2D.OverlapCircle(controladorSuelo.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(WalkSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        WalkSpeed *= -1;
        mustPatrol = true;
        
    } */
     
