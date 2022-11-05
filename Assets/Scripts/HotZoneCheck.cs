using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
     private Suki enemyParent;
     private bool enRango;
     private Animator ani;

     private void Awake() {

        enemyParent = GetComponentInParent<Suki>();
       ani = GetComponent<Animator>();
     }

     private void OnTriggerEnter2D (Collider2D collider) {

            if (collider.gameObject.CompareTag("Player")) {
            
            enRango = true;
           
        }

     }

    // Update is called once per frame
    private void Update()
    {
        if (enRango && !ani.GetCurrentAnimatorStateInfo(0).IsName ("suki-peleando_0") ) //
        {
            enemyParent.Flip();
        }
    }

    private void OnTriggerExit2D (Collider2D collider) {

        if (collider.gameObject.CompareTag("Player")) {

            enRango = false;
             gameObject.SetActive(false);
             enemyParent.triggerArea.SetActive(true);
              enemyParent.enRango = false;
              enemyParent.SelecTarget();
        }

    }
}
