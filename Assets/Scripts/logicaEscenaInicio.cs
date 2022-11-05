using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicaEscenaInicio : MonoBehaviour
{
    void Start()
    {
      /* PARA FUTURO SONIDO
      Scene = sceneManager.GetActiveScene();
      if(scene.name == "MainMenu")
      {
        AudioManager.instance.backgroundMusic.Stop();
      } */
       // Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarEscena()
    {
      SceneManager.LoadScene(11);
    }
}
