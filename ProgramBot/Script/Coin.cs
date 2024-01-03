using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject objeto;
    [SerializeField] private Point point;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            point.AddPoints();
            objeto.gameObject.SetActive(false);
        }
    }
}
