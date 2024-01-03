using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Virus"))
        {
            Debug.Log("Collision with Virus detected");
            GameManager.Instance.GameOver();
        }
    }
}
