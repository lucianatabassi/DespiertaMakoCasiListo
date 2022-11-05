using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public float PuntosVida; //conteo de vida
    public float vidaMax = 3; 
    [SerializeField] private GameObject efectoExplosion;


      public Transform  player_pos; // acceso a la posicion del personaje principal 
   public float vel;
   public float distancia_frenado;
   public float distancia_retroceso;

    public float tiempoDisparo;
    public Transform PuntoDisparoEnemy;
    public BalaEnemigo bala;
    
    
    // Start is called before the first frame update
    void Start()
    {

        PuntosVida = vidaMax;

        player_pos = GameObject.Find("Personaje").transform; // setear la posicion del personaje
    }

    // Update is called once per frame
    void Update()
    {
        if (player_pos == null) { // cuando muere el personaje que deja de ejecutarse el codigo de seguimiento
            return;
        }
        // para dividir codigo (movimiento de enemigo)
        #region

        // si la dist entre personaje y enemigo es mayor a la dist de frenado entonces q se mueva el enemigo 
        if(Vector2.Distance(transform.position, player_pos.position) > distancia_frenado) {
    transform.position = Vector2.MoveTowards (transform.position, player_pos.position, vel * Time.deltaTime); // que se desplace de la pos actual a la pos de destino
        }

    // si la dist entre personaje y enemigo es menor a la dist de retroceso entonces q el enemigo retroceda 
        if(Vector2.Distance(transform.position, player_pos.position) < distancia_retroceso) {
    transform.position = Vector2.MoveTowards (transform.position, player_pos.position, -vel * Time.deltaTime); 
        }

    // que el enemigo se mantenga quieto
        if(Vector2.Distance(transform.position, player_pos.position) < distancia_frenado && Vector2.Distance(transform.position, player_pos.position) > distancia_retroceso) {
    transform.position = transform.position;
        }
        
        #endregion
   
   // enemigo mira al personaje
    #region 

    //si la pos x del personaje es mayor a pos x del enemigo, q este lo mire
    if (player_pos.position.x > this.transform.position.x) {
         gameObject.GetComponent <Animator>().SetBool("quiet", true);
        //this.transform.localScale = new Vector2(-6, 6); // si el personaje esta  la derecha q el enemigo mire para ahi
         this.transform.eulerAngles = new Vector3 (0, 180, 0);
    } else {
       //this.transform.localScale = new Vector2(6, 6); // si el personaje esta  la izquierda q el enemigo mire para ahi
        this.transform.eulerAngles = new Vector3 (0, 0, 0);
    }
    #endregion
    

    //disparo
    
    tiempoDisparo += Time.deltaTime;
    if (tiempoDisparo >=2) {
        Instantiate(bala, PuntoDisparoEnemy.position, transform.rotation);
        tiempoDisparo = 0;
    }
   
    }

    public void TakeHit(float golpe) { //funcion / se asigna el golpe/daño asignado en el script bullet
        PuntosVida -= golpe; //golpe resta a puntos devida
        if (PuntosVida <=0 ) {

            Muerte();         
                       
            
        }  
        
    }

    private void Muerte() {
        Instantiate(efectoExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
    }
}
