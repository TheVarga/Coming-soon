using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Vector3 localScale;

    private void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        EnemyAI enemyAI = gameObject.GetComponentInParent<EnemyAI>();
        localScale.x = enemyAI.Health/enemyAI.MaxHealth/2;
        
        transform.localScale = localScale;
    }
}
