using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float damage;
    bool dealtDamage = false;
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
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dealtDamage == false) { 
        
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyProjectile")) return;
            if (collision.CompareTag("Player"))
            {
      
                GameObject enemyObject = collision.gameObject;
                PlayerController playerController = enemyObject.GetComponent<PlayerController>();
                playerController.TakeDamage(damage);
                Debug.Log("Player hit Hit: " + damage);
            }
            dealtDamage = true;
        }
        Destroy(gameObject);
    }
}
