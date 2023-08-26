using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float shootingSpeed;
    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = transform.right * shootingSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);

        }
    }
}
