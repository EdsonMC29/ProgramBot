using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColorChange : MonoBehaviour
{
    public Color nuevoColor; 
    public Transform objetoCambiarColor; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Renderer renderer = objetoCambiarColor.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.material.color = nuevoColor;
            }
        }
    }
}
