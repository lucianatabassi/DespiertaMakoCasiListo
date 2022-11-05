using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckpointBossTemp : MonoBehaviour
{

 void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.CompareTag("Player"))
    {
        
         CambiarEscena();
        // collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
    }
}
      void CambiarEscena()
    {
      SceneManager.LoadScene(6);

      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
