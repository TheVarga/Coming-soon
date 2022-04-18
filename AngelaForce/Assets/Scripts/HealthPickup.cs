using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float HealthAmount;
    private bool alreadyHealed = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            GameObject playerObject = collision.gameObject;
            PlayerController playerController = playerObject.GetComponent<PlayerController>();
            if (!alreadyHealed)
            {
                if (!playerController.Health.Equals(playerController.MaxHealth))
                {
                    if (playerController.Health + HealthAmount >= playerController.MaxHealth)
                    {
                       
                        float reducedHealing = HealthAmount + 
                            (playerController.MaxHealth - (playerController.Health + HealthAmount));
                        playerController.Health += reducedHealing;
                        Destroy(gameObject);
                    }
                    else
                    {
                        playerController.Health += HealthAmount;
                        Destroy(gameObject);
                    }
                    alreadyHealed = true;
                }
            }
            
            
        }
    }
}
