using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteColliderPelea : MonoBehaviour
{
    public bool limite;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        limite = GetComponent<Collider2D>().isTrigger = true;
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            timer++;

            if(timer >= 5)
            {
                limite = GetComponent<Collider2D>().isTrigger = false;
            }
            
           
        }
    }
    
}
