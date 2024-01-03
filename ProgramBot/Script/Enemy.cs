using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Point point;
    public GameObject objeto;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            point.gameOver();
            objeto.gameObject.SetActive(false);
        }
    }
}
