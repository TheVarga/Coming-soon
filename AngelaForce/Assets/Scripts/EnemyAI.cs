using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";


    [SerializeField]
    Transform castPosition;

    [SerializeField]
    float baseCastDistance;

    string facingDirection;

    Vector3 baseScale;

    Rigidbody2D rb2d;
    float moveSpeed = 5;
    void Start()
    {
        facingDirection = RIGHT;
        baseScale = transform.localScale;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                if (facingDirection == LEFT)
                {
                    ChangeFacingDirection(RIGHT);
                }
                else
                {
                    ChangeFacingDirection(LEFT);
                }           
        }
        
    }

    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }

        rb2d.velocity = new Vector2(vX, rb2d.velocity.y);


        if (IsHittingWall() || IsNearEdge())
        {
            if (facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else
            {
                ChangeFacingDirection(LEFT);
            }
        }

    }

    void ChangeFacingDirection(string direction)
    {
        Vector3 newScale = baseScale;
        if (direction == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else
        {
            newScale.x = baseScale.x;
        }
        transform.localScale = newScale;
        facingDirection = direction;
    }

    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDistance;
        //define cast dist
        if (facingDirection == LEFT)
        {
            castDist = -baseCastDistance;
        }
        //target destination based on cast distance
        Vector3 targetPos = castPosition.position;
        targetPos.x += castDist;

        //Debug.DrawLine(castPosition.position, targetPos, Color.red);

        if (Physics2D.Linecast(castPosition.position, targetPos, 1 << LayerMask.NameToLayer("Platform")))
        {
            val = true;
        }
        else val = false;

        return val;
    }

    bool IsNearEdge()
    {
        bool val = true;

        float castDist = baseCastDistance;

        //target destination based on cast distance
        Vector3 targetPos = castPosition.position;
        targetPos.y -= castDist;

        // Debug.DrawLine(castPosition.position, targetPos, Color.green);

        if (Physics2D.Linecast(castPosition.position, targetPos, 1 << LayerMask.NameToLayer("Platform")))
        {
            val = false;
        }
        else val = true;

        return val;
    }

}
