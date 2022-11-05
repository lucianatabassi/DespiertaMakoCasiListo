using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossLevelLoader : MonoBehaviour
{
public Animator transition; 
public float transitionTime = 1f;

    void Update()
    {
        
    }
    public void loadNextLevel()
    {
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }
    IEnumerator LoadLevel(int levelIndex)
    {
      //Play animation
      transition.SetTrigger( "start"); //Le pasamos el nombre de la animacion inicial

      //Wait
      yield return new WaitForSeconds(transitionTime);
      //Load scene
      SceneManager.LoadScene(levelIndex);
    }
}