using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Color turnOffColor; 
    public Color turnOnColor; 
    public GameObject plate; 
    private bool isActivated;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TurnOn();
        }
    }

    void Start()
    {
        TurnOff();
    }

    public bool IsOn()
    {
        return isActivated;
    }

    public void TurnOn()
    {
        isActivated = true;
        Renderer plateRenderer = plate.GetComponent<Renderer>();
        if (plateRenderer != null)
        {
            plateRenderer.material.color = turnOnColor;
        }
    }

    public void TurnOff()
    {
        isActivated = false;
        Renderer plateRenderer = plate.GetComponent<Renderer>();
        if (plateRenderer != null)
        {
            plateRenderer.material.color = turnOffColor;
        }
    }
}
