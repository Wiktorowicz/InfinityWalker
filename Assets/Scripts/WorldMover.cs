using UnityEngine;

public class WorldMover : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}