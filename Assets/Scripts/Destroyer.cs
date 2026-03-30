using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
        }
    }
}