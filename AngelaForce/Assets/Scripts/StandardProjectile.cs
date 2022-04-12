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
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
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
