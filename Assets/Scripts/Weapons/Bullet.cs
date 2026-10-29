using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody rb;


    private void Start()
    {
        //Detruit la balle dans 15 secondes
        //C'est un * Garde fou *
        Destroy(gameObject, 15);
    }

    public void Fire(Vector3 direction, float speed)
    {
        rb.linearVelocity = direction.normalized * speed;
    }
}
