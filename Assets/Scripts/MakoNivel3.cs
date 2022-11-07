using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class MakoNivel3 : MonoBehaviour
{

public Transform PuntoDisparo;  // desde donde sale la bala
    public GameObject Bullet; // img bala

    public float velCorrer;
    public float velSaltar;
    Rigidbody2D rb2D;

    public float puntosVidaPlayer; 
    public float vidaMaxPlayer = 3;
    public Image barraDeVida;

    public Image  nivelEnergia;
    public int cantEnergia;
    public GameObject[] Barras;

    public Animator anim;
 /*    public bool isAttacking = false; */
   // public static MakoNivel3 scriptMako;

    [Header("Sonidos")]
    public GameObject DisparoSonido;
    public GameObject PUSonido;
    public GameObject SaltoSonido;
    public GameObject[] HeridaSonido;

    //VideoPlayer cinematica;
    //Cinematica
   /*     public Animator transition; 
       public float transitionTime = 1f;

    private void Awake() { // para acceder al script desde cualquier parte
        scriptMako = this;
    } */
    

 
    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        anim = GetComponent<Animator>();
        puntosVidaPlayer = vidaMaxPlayer;
        rb2D = GetComponent<Rigidbody2D>(); // mete el componente rigidbody dentro de la variable
       // cinematica = GetComponent<VideoPlayer>();
       
        
        nivelEnergia.GetComponent<Image>().color = new Color (0, 240, 255 );
        //energia.GetComponent<Image>().color = new Color (0, 240, 255  );

        // BARRITAS DE ENERGIA
    for (int i = 0; i < cantEnergia; i++) {
        Barras [i].gameObject.SetActive(true);
        Barras[i].GetComponent<Image>().color = new Color (0, 240, 255  );

    }


    }
 

    void Update()
    {
 
 
        barraDeVida.fillAmount = puntosVidaPlayer / vidaMaxPlayer;

    if (Input.GetKey("a")) 
    {
        rb2D.velocity = new Vector2 (-velCorrer  , rb2D.velocity.y); // en que direccion ir (eje Y se queda como esta)
        //gameObject.GetComponent <Rigidbody2D>().AddForce(new Vector2(-800f * Time.deltaTime, 0));
        gameObject.GetComponent <Animator>().SetBool("mooving", true);
        gameObject.GetComponent <Animator>().SetBool("shoot", false);
    /*     gameObject.GetComponent <Animator>().SetBool("fight", false); */
        gameObject.GetComponent <Animator>().SetBool("jump", false);
        anim.SetBool("falling", false);
         anim.SetBool("crouch", false);
       //gameObject.GetComponent <SpriteRenderer>().flipX = true;
       transform.eulerAngles = new Vector3 (0,180, 0); // para voltear al personaje             
    } 

    if (Input.GetKey("a") && Input.GetKey("space") ) {
        gameObject.GetComponent <Animator>().SetBool("jump", true);
    }
   

    if (Input.GetKey("d")) 
    {
         rb2D.velocity = new Vector2 (velCorrer , rb2D.velocity.y); // en que direccion ir (eje y se queda como esta)
       // gameObject.GetComponent <Rigidbody2D>().AddForce(new Vector2(800f * Time.deltaTime, 0));
        gameObject.GetComponent <Animator>().SetBool("mooving", true);
        gameObject.GetComponent <Animator>().SetBool("shoot", false);
      /*   gameObject.GetComponent <Animator>().SetBool("fight", false); */
        gameObject.GetComponent <Animator>().SetBool("jump", false);
        anim.SetBool("falling", false);
        anim.SetBool("crouch", false);
        //gameObject.GetComponent <SpriteRenderer>().flipX = false;
        transform.eulerAngles = new Vector3 (0,0, 0); // para voltear al personaje
         
       
        
    } 

   if (Input.GetKey("d") && Input.GetKey("space") ) {  //
        gameObject.GetComponent <Animator>().SetBool("jump", true);
       //anim.SetBool("falling", false);
    }

    if (Input.GetKey ("space") ) { 

        if (checkGround.estaEnSuelo)
        {
            rb2D.velocity = new Vector2 (rb2D.velocity.x, velSaltar); 
            NuevoSonido(SaltoSonido, 1f);
        }            
            anim.SetBool("jump", true);
            anim.SetBool("falling", false);
            anim.SetBool("crouch", false);
               
    }




     if (rb2D.velocity.y < 0 )
    {
        
       // anim.SetBool("jump", false);
        anim.SetBool("falling", true);
    } 
    
    else if (rb2D.velocity.y > 0)
    {
        anim.SetBool("falling", false);
    }

    if (Input.GetKey("s")) // agacharse
    {
        anim.SetBool("crouch", true);
        //anim.SetBool("falling", false);
    } else {
        anim.SetBool("crouch", false);
       // anim.SetBool("falling", false);
    }




    if (!Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKeyDown("w") && !Input.GetKey ("space") ) { // esto es para que las animaciones no sigan funcionando cuando se dejan d presionar las teclas
         gameObject.GetComponent <Animator>().SetBool("mooving", false);
         gameObject.GetComponent <Animator>().SetBool("jump", false);
        
           
    }


    if (Input.GetKey("mouse 0")) { //dispara con el mouse
        gameObject.GetComponent <Animator>().SetBool("shoot", true);
     /*    gameObject.GetComponent <Animator>().SetBool("fight", false); */
        anim.SetBool("crouch", false);
      
    }
   
    if (Input.GetKeyDown ("mouse 0")) { //dispara con el mouse
        if (cantEnergia > 0  ) { // && puedoDisparar 
            GameObject prefab = Instantiate(Bullet, PuntoDisparo.position, transform.rotation) as GameObject; // crea objeto en base a la rotacion           
                cantEnergia -= 1;        
                NuevoSonido(DisparoSonido, 1f);
               Destroy(prefab, 2f);

               // puedoDisparar = false;
               // // StartCoroutine(EsoerarDisparo())
        }  

        // }
        
        Barras [cantEnergia].gameObject.SetActive(false);
       
    }

    /*
    Profe

    bool puedoDisparar = false;

    EsperarDisparo() {
        yield return new WaitForSecndos( frecuencia disparo )
        puedoDisparar = true;

    }
    
    */



   /* if (cantEnergia <=0) { //si no tiene energia, no dispara
        Destroy(energia);
       
    }*/

/*         Ataque(); */
    /*if (Input.GetKeyDown ("mouse 1")) { // con boton derecho del mouse pelea

        
        gameObject.GetComponent <Animator>().SetBool("fight", true);
    }*/


    // hud de energia se pone rosa
    if (cantEnergia <=4 ) {
       for (int i = 0; i < cantEnergia; i++) {
        Barras [i].gameObject.SetActive(true);
        Barras[i].GetComponent<Image>().color = new Color (255, 0, 255 );

    }

    nivelEnergia.GetComponent<Image>().color = new Color (255, 0, 255);
      
    }

    //vuelve a celeste
    if (cantEnergia >=5) {
        for (int i = 0; i < cantEnergia; i++) {
        Barras [i].gameObject.SetActive(true);
        Barras[i].GetComponent<Image>().color = new Color (0, 240, 255);

    }
        nivelEnergia.GetComponent<Image>().color = new Color (0, 240, 255);
    }
    }

/*     void Ataque() {
        if (Input.GetKeyDown ("mouse 1") && !isAttacking) {
            isAttacking = true;
        }
    } */




   private void OnTriggerEnter2D (Collider2D col) { //cuando collider entra en contacto con otro collider


        //JUNTAR BALAS (ENERGIA)
       if (col.gameObject.tag == "balas" && cantEnergia < 8 ) {
              Destroy(col.gameObject);
    
              cantEnergia +=2;
              NuevoSonido(PUSonido, 1f);


    for (int i = 0; i < cantEnergia; i++) {
        Barras [i].gameObject.SetActive(true);

    } 

    
       } 

       if (col.gameObject.tag == "balas" && cantEnergia == 8) {
        Destroy(col.gameObject);
    
              cantEnergia +=1;          
              NuevoSonido(PUSonido, 1f);


    for (int i = 0; i < cantEnergia; i++) {
        Barras [i].gameObject.SetActive(true);

    } 
       }

       
    }

    private void OnCollisionEnter2D (Collision2D collision) { // verificar q colisionamos con la plataforma cuando se mueve
/*         if (collision.gameObject.tag == "plataformaMovible") {
            transform.parent = collision.transform;
            anim.SetBool("falling", false);
            

        } */
     if (collision.gameObject.tag == "balaBoss" ) { // animacion de dano
        anim.SetTrigger ("hurt");
            if (puntosVidaPlayer <=0) {

         CambiarEscenaGameOver();


    }
        
    }


    }

/*     private void OnCollisionExit2D (Collision2D collision) { // q el personaje ya no se mueva con la plataforma cuando ya se bajo
        if (collision.gameObject.tag == "plataformaMovible") {
            transform.parent = null;

        }
    } */


    public void TakeHit (float golpe) { // personaje pierde vida
        puntosVidaPlayer -= golpe;
       NuevoSonido(HeridaSonido[0], 1f);
        gameObject.GetComponent <Animator>().SetBool("hurt", true);
         if (puntosVidaPlayer <=0) {
             CambiarEscenaGameOver();
        }


    }
/* 
    public void golpeSuki (float dano) { // dano de suki
        puntosVidaPlayer -= dano;
         gameObject.GetComponent <Animator>().SetBool("hurt", true);
        NuevoSonido(HeridaSonido[Random.Range(0, 2)], 1f);
    if (puntosVidaPlayer <=1) {

         CambiarEscena();
        // Destroy(gameObject);
        /*if(!cinematica.isPlaying){
            cinematica.Play();
        } else {
            cinematica.Stop();
        }*/
        

/* 

    }

      void CambiarEscena()
    {
      SceneManager.LoadScene(3);

      
    }


    }
    */
     void CambiarEscenaGameOver()
     {
        SceneManager.LoadScene(9);
     }
    void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }  
}
