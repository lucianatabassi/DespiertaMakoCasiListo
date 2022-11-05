using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SukiPatrol : MonoBehaviour
{
    [Header ("Patrullaje")]
   [SerializeField] private Transform izqLimite;
   [SerializeField] private Transform derLimite;

    [Header ("Suki")]
    [SerializeField] private Transform suki;

    [Header ("Parametros")]
    [SerializeField] private float vel;
    private Vector3 escalaInicial;
    private bool movIzq;
    [SerializeField] private float idleDuracion;
     private float idleTimer;

    [Header ("Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        escalaInicial = suki.localScale; // guarda la pos inicial de suki
    }

   /* private void OnDisable() 
    {
        anim.SetBool("caminar", false);
    }*/

    private void Update()
    {
        if (movIzq)
        {
            if (suki.position.x >= izqLimite.position.x )
            {
                DirMovimiento(-1);
            } else
            {
               CambiaDir();
            }
            
        } else
        {
            if(suki.position.x <= derLimite.position.x) 
            {
                DirMovimiento(1);
            } else 
            {
                CambiaDir();
            }
            
        }
         
    }

    private void CambiaDir()
    {
        anim.SetBool("caminar", false);
      
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuracion )
        {
             movIzq = !movIzq;
        }
      
    }

   private void DirMovimiento (int _direccion)
   {
        idleTimer = 0;
        anim.SetBool("caminar", true);

       // que suki mire en una direccion
     suki.localScale = new Vector3 (Mathf.Abs(escalaInicial.x)  * _direccion, escalaInicial.y, escalaInicial.z); 

     //que se mueva hacia esa direccion
     suki.position = new Vector3 (suki.position.x + Time.deltaTime * _direccion * vel, suki.position.y, suki.position.z);
   }
}
