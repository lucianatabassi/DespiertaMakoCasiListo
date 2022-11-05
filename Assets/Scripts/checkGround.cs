using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public static bool estaEnSuelo; //static significa q se puede usar la variable dentro de otro script

    private void OnTriggerEnter2D (Collider2D collision) {
        estaEnSuelo = true;
        
        
        
    }

    private void OnTriggerExit2D (Collider2D collision) {
         estaEnSuelo = false;
        
    }
}
