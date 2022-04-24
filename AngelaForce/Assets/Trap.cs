using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float TrapDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject gameObject = collision.gameObject;
            PlayerController controller = gameObject.GetComponent<PlayerController>();
            controller.TakeDamage(TrapDamage / 2);
        }
    }
    
}
