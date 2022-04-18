using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : MonoBehaviour
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
        if (dealtDamage == false)
        {
            if(collision.CompareTag("Player") || collision.CompareTag("PlayerProjectile")) return;
            if (collision.CompareTag("DestroyableTerrain"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.CompareTag("Enemy"))
            {
                dealtDamage = true;
                GameObject enemyObject = collision.gameObject;
                EnemyAI enemyStats = enemyObject.GetComponent<EnemyAI>();
                enemyStats.Health -= damage;
                Debug.Log("Hit: " + enemyStats.Health);
            }
        }
        



        Destroy(gameObject);
    }
   
}
