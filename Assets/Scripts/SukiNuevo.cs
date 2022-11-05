using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SukiNuevo : MonoBehaviour
{
    [SerializeField] private float ataqueCooldown;
    [SerializeField] private float daño;
    [SerializeField] private int rango;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDist;
    [SerializeField] private LayerMask makoLayer;
    public Transform mako_pos;
     private float coolDownTimer = Mathf.Infinity;

     private Animator anim;

     private SukiPatrol enemyPatrol;

     [Header("Sonidos")]
    public GameObject[] PeleaSonido;


    private void Awake() 
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<SukiPatrol>();
        mako_pos = GameObject.Find("Personaje").transform;
    }


    private void Update() {

        coolDownTimer += Time.deltaTime;

        if (makoEnRango())
        {
            if (coolDownTimer >=ataqueCooldown) // ataque cuando mako esta en la vista
        {
            coolDownTimer = 0;
            anim.SetTrigger("pelear");
            //Flip();
             //anim.SetBool("caminar", false);
            Debug.Log("aaa");
            //Ataque();
        }
        }

        if (enemyPatrol != null) {
            enemyPatrol.enabled = !makoEnRango();
        }
           
    }
        
    

    private bool makoEnRango()
    {
        RaycastHit2D hit = Physics2D.BoxCast (boxCollider.bounds.center + transform.right * rango * transform.localScale.x * colliderDist, new Vector3(boxCollider.bounds.size.x * rango, boxCollider.bounds.size.y, boxCollider.bounds.size.z ), 0, Vector2.left, 0, makoLayer );

       
        return hit.collider != null;
    }

  /*  private void Flip() 
    {
         if(mako_pos.position.x>this.transform.position.x)
       {

            this.transform.eulerAngles = new Vector3 (0, 180, 0);

    } else {
 
            this.transform.eulerAngles = new Vector3 (0, 0, 0);
    }


    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * rango * transform.localScale.x * colliderDist, new Vector3(boxCollider.bounds.size.x * rango, boxCollider.bounds.size.y, boxCollider.bounds.size.z ));
    }
    
    void OnTriggerEnter2D(Collider2D trig) {
    var player = trig.GetComponent<PlayerControler>();

        if (player ) { 
            player.golpeSuki (daño);
           NuevoSonido(PeleaSonido[Random.Range(0, 3)], 1f);
            
        }

        if (trig.gameObject.tag == "golpes")
            {
                anim.SetTrigger("herida");
            }

}

        void OnCollisionEnter2D (Collision2D col) 
        {
            if (col.gameObject.tag == "Player")
            {
                anim.SetTrigger("herida");
            }
            
        }

/*public void TakeHit(float golpe)
    {
        
        anim.SetTrigger("herida");
         //NuevoSonido(SonidoEnemigoHerido[0], 1f);
        
    }*/

 void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }

}

