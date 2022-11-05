using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayInside : MonoBehaviour
{
    private Transform theTransform;
    public Vector2 Hrange = Vector2.zero; //Rango horizontal
    public Vector2 Vrange = Vector2.zero;//Rango vertical
    // Update is called once per frame
    void LateUpdate()
    {
        theTransform.position = new Vector3 (
            Mathf.Clamp (transform.position.x, Vrange.x, Vrange.y),
            Mathf.Clamp (transform.position.y, Hrange.x, Hrange.y), //Sirve para crear un limite/rango
            transform.position.z
        );
    }

    void Start (){
        theTransform = GetComponent<Transform> ();
    }
}
