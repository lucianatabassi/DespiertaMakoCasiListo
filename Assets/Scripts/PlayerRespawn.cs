using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }
    public void ReachedCheckPoint(float x, float y) //guarda la pos del cp
    {
      PlayerPrefs.SetFloat("checkPointPositionX",x); //guarda pos en el eje x
      PlayerPrefs.SetFloat("checkPointPositionY",y);
    }
}
