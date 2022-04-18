using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPickup : MonoBehaviour
{
    
    public int PointValue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && collision.GetType().Name.Equals("BoxCollider2D"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.Points += PointValue/2;
            Destroy(gameObject);
        }
    }
}
