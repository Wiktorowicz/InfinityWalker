using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("DOTKNĄŁEM: " + other.name);

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
        }
    }
}