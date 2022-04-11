using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.localScale.x * transform.right);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerProjectile")) return;
        if (collision.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
        }
        



        Destroy(gameObject);
    }
}
