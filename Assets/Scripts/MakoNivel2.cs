using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MakoNivel2 : MonoBehaviour
{
    public float velCorrer;
    public float velSaltar;
    Rigidbody2D rb2D;
   
    public Animator anim;

    public float puntosVidaPlayer; 
    public float vidaMaxPlayer;
    public Image barraDeVida;

    [Header("Sonidos")]
    public GameObject SaltoSonido;
    public GameObject DeschipeoSonido;
    public GameObject[] HeridaSonido;

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;
    //public Camera cam;



    // Start is called before the first frame update
    void Start()
    {
       /*cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;*/

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
         puntosVidaPlayer = vidaMaxPlayer;
         
    }

    // Update is called once per frame
    void Update()
    {
       /* float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);*/

        barraDeVida.fillAmount = puntosVidaPlayer / vidaMaxPlayer;


        if (Input.GetKey("a")) 
    {
        rb2D.velocity = new Vector2 (-velCorrer  , rb2D.velocity.y); // en que direccion ir (eje Y se queda como esta)
        anim.SetBool("correr", true);
        anim.SetBool("deschipear", false);
        anim.SetBool("saltar", false);
         anim.SetBool("agachar", false);
        anim.SetBool("caer", false);
        transform.eulerAngles = new Vector3 (0,180, 0); // para voltear al personaje             
    } 

    if (Input.GetKey("a") && Input.GetKey("space") ) {
        anim.SetBool("saltar", true);
    }

    if (Input.GetKey("d")) 
    {
         rb2D.velocity = new Vector2 (velCorrer , rb2D.velocity.y); // en que direccion ir (eje y se queda como esta)
        anim.SetBool("correr", true);
        anim.SetBool("deschipear", false);
        anim.SetBool("saltar", false);
         anim.SetBool("agachar", false);
        anim.SetBool("caer", false);
        transform.eulerAngles = new Vector3 (0,0, 0); // para voltear al personaje
         
       
        
    } 

    if (Input.GetKey("d") && Input.GetKey("space") ) {
        anim.SetBool("saltar", true);
    }

    if (Input.GetKey ("space") ) { 

        if (checkGround.estaEnSuelo)
        {
            rb2D.velocity = new Vector2 (rb2D.velocity.x, velSaltar);  
             NuevoSonido(SaltoSonido, 1f);
        }
        
             
            anim.SetBool("saltar", true);
             anim.SetBool("caer", false);
             anim.SetBool("agachar", false);
             
           
    
    }

    if (Input.GetKey ("space")) // si esta sobre una plataforma puede saltar 
    {

        if ( tocaPlataforma.enPlat )
        {
            rb2D.velocity = new Vector2 (rb2D.velocity.x, velSaltar);
            NuevoSonido(SaltoSonido, 1f);
        }
       
        
        anim.SetBool("correr", false);
        anim.SetBool("saltar", true);
        anim.SetBool("caer", false);
         anim.SetBool("agachar", false);
         
         
        
    }

    if (rb2D.velocity.y < 0 )
    {
       // anim.SetBool("saltar", false);
        anim.SetBool("caer", true);
    } 
    
    else if (rb2D.velocity.y > 0)
    {
        anim.SetBool("caer", false);
    }



    if (Input.GetKey("s")) // agacharse
    {
        anim.SetBool("agachar", true);
       // anim.SetBool("caer", false);
    } else {
        anim.SetBool("agachar", false);
        //anim.SetBool("caer", false);
    }


    if (!Input.GetKey("a") && !Input.GetKey("d") && !Input.GetKeyDown("w") && !Input.GetKey ("space") ) { // esto es para que las animaciones no sigan funcionando cuando se dejan d presionar las teclas
        anim.SetBool("correr", false);
        anim.SetBool("saltar", false);
       
           
    }

        if (Input.GetKey("mouse 0")) { //dispara con el mouse
        anim.SetBool("deschipear", true);
         anim.SetBool("agachar", false);
       
    } else {
         anim.SetBool("deschipear", false);
    }

     
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        if (collider.gameObject.tag == "enemigo1")
        {
            //Camera.main.GetComponent<Camera>().backgroundColor = new Color32(255,255,255,0);
           // ChangeColor();
            NuevoSonido(DeschipeoSonido, 1f);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) { // verificar q colisionamos con la plataforma cuando se mueve
        if (collision.gameObject.tag == "plataformaMovible") {
            transform.parent = collision.transform;
            anim.SetBool("caer", false);
            

        }
     if (collision.gameObject.tag == "balaEnemigo" ) { // animacion de daño
        anim.SetTrigger ("herida");
        
    }


    }


     private void OnCollisionExit2D (Collision2D collision) { // q el personaje ya no se mueva con la plataforma cuando ya se bajo
        if (collision.gameObject.tag == "plataformaMovible") {
            transform.parent = null;

        }
    }


    public void TakeHit (float golpe) { // personaje pierde vida
        puntosVidaPlayer -= golpe;
       NuevoSonido(HeridaSonido[0], 1f);
        gameObject.GetComponent <Animator>().SetBool("herida", true);
         if (puntosVidaPlayer <=0) {
            anim.SetTrigger("muerta");
            CambiarEscenaGameOver();
            //Destroy(gameObject);
        }


    }

    void NuevoSonido (GameObject prefab, float duracion = 5f) {
         Destroy (Instantiate(prefab), duracion);
    }

    /* void ChangeColor()
{
     float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);
}*/

    void CambiarEscenaGameOver()
     {
        SceneManager.LoadScene(10);
     }

     
}
