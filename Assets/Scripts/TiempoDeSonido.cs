using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoDeSonido : MonoBehaviour
{
    public float tiempoVida;
    // Start is called before the first frame update
    void Start()
    {
        Destroy (gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
