using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private Suki enemyParent;

    private void Awake () {
        enemyParent = GetComponentInParent<Suki>();
    }

    private void OnTriggerEnter2D (Collider2D collider) {

        if (collider.gameObject.CompareTag("Player")) {

            gameObject.SetActive(false);
            enemyParent.mako = collider.transform;
            enemyParent.enRango = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
