using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Suki : MonoBehaviour
{
    //public Transform rayCast;
    //public LayerMask raycastMask;
    //public float rayCastLength;
    public float distAtaque; //dist min de ataque
    public float vel;
    public float timer; // tiempo entre ataques
    public float hit = 1;
    public Transform izqLimite;
    public Transform derLimite;
    [HideInInspector] public Transform mako;
    [HideInInspector] public bool enRango;
    public GameObject hotZone;
    public GameObject triggerArea;
   

    private RaycastHit2D golpe;
    //private GameObject mako;
   // private Transform mako;
    private Animator ani;
    private float dist; // guardar dist entre mako y suki
    private bool sukiAtaque;
    //private bool enRango; // chequear si mako esta dentro del rango de ataque
    private bool cooling; // chequear si suki se calmo
    private float intTimer;



    [Header("Sonidos")]
    public GameObject[] PeleaSonido;


    void Awake () {

        SelecTarget();
        intTimer = timer;
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (sukiAtaque)
        {
            Flip();
        }
            

        /* if (!sukiAtaque)    {
            Move();
         }*/

         if (!Limites() && !enRango && !ani.GetCurrentAnimatorStateInfo(0).IsName ("suki-peleando_0"))
         {
            SelecTarget();
         }

       /* if (enRango) {
           // golpe = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
           golpe = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask);
            RaycastDebugger();
        }*/


        //cuando mako es detectada
      /*  if (golpe.collider !=null) {
            sukiLogic();
        } else if (golpe.collider == null) {
            enRango = false;
        }*/

        //if (enRango == false) { // cuando mako no este dentro del rango, que suki no ataque
           
           if (enRango) {
           // ani.SetBool("sukiWalk", false);
           // StopAttack();
           sukiLogic();
        }
    }


    void sukiLogic() {
        //dist = Vector2.Distance (transform.position, mako.transform.position); // calcula dist entre mako y suki
         dist = Vector2.Distance (transform.position, mako.position);

        if (dist > distAtaque) { //si la dist entre ellas es mayor que la dist de ataque entonces q se mueva hacia mako
           // Move();
            StopAttack();
        } 
        else if (distAtaque >= dist && cooling == false) {
            Ataque();
           
        }

        if (cooling) {
            Cooldown();
            ani.SetBool ("sukiAttack", false);
        }
    }

   /*void OnTriggerEnter2D(Collider2D trig) {
    var player = trig.GetComponent<PlayerControler>();

       

        /*if (trig.gameObject.tag == "Player") {
            //mako = trig.gameObject; // guarda la pos de mako
            mako = trig.transform; // guarda la pos de mako
            enRango = true;
           Flip();

        }

        if (player ) { //&& trig.gameObject.tag == "golpes"
            player.golpeSuki (hit);
            NuevoSonido(PeleaSonido[Random.Range(0, 3)], 1f);
            
        }

       
    }

   /* void OnCollisionEnter2D (Collision2D col) {
        var player = col.collider.GetComponent<PlayerControler>();

        if (player && col.gameObject.tag == "golpes") {
            player.golpeSuki (hit);
            NuevoSonido(PeleaSonido[Random.Range(0, 3)], 1f);
            
        }
    }*/

    

   /* void Move () {
        ani.SetBool ("sukiWalk", true);
        if (!ani.GetCurrentAnimatorStateInfo(0).IsName ("suki-peleando_0")) {
            //Vector2 makoPosition = new Vector2 (mako.transform.position.x, transform.position.y ); // que se mueva a la pos de mako
           Vector2 makoPosition = new Vector2 (mako.position.x, transform.position.y );
            transform.position = Vector2.MoveTowards(transform.position, makoPosition, vel * Time.deltaTime);
            
        }
    }*/

    void Ataque () {
        timer = intTimer; // resetea el tiempo cuando mako entra en rango
        sukiAtaque = true;

        ani.SetBool ("sukiWalk", false);
        ani.SetBool ("sukiAttack", true);

        
        
    }


    void Cooldown() {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && sukiAtaque ) {
            cooling = false;
            timer = intTimer;

        }
    }
    void StopAttack() {
        cooling = false;
        sukiAtaque = false;
        ani.SetBool("sukiAttack", false);
    }

  /*  void RaycastDebugger() {
        if (dist > distAtaque) {
           // Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
           Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (distAtaque > dist) {
           // Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
           Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }*/

    public void TriggerCooling () {
        cooling = true;
    }

    public void Flip() {

        
     /* Vector3 rotation = transform.eulerAngles;
        if ( transform.position.x < mako.position.x  )
        {
            rotation.y = 180;
           // this.transform.eulerAngles = new Vector3 (0,180, 0);
           //sprites.flipX = true;
        } else {
           // sprites.flipX = false;
            rotation.y = 0;
           // this.eulerAngles = new Vector3 (0,0, 0);
        }

       transform.eulerAngles = rotation;*/

     if(mako.position.x > this.transform.position.x  ) //transform.position.x > target.position.x mako.position.x>this.transform.position.x
       {

            this.transform.eulerAngles = new Vector3 (0, 180, 0);

    } else {
 
            this.transform.eulerAngles = new Vector3 (0, 0, 0);
    }

    }

    private bool Limites() {
        return transform.position.x > izqLimite.position.x && transform.position.x < derLimite.position.x;
    }

    public void SelecTarget() {
        float distToIzq = Vector2.Distance(transform.position, izqLimite.position);
        float distToDer = Vector2.Distance(transform.position, derLimite.position);

        if (distToIzq > distToDer)
        {
            mako = izqLimite;
        } else {
             mako = derLimite;
        }

        Flip();
    }

    void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }
 
}
