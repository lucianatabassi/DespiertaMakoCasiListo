using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocaPlataforma : MonoBehaviour
{
    public static bool enPlat; //static significa q se puede usar la variable dentro de otro script
    

    void Start() {
        
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        enPlat = true;
       
        
        
        
    }

    private void OnTriggerExit2D (Collider2D collision) {
         enPlat = false;
        
    }
}
