using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";
    public float MaxHealth;
    public float Health;
    public float CollisionDamage;
    //Shooting
    //public AudioSource gunSound;
    private bool canShoot = true;
    private int crLimit = 0;
    public GameObject projectile;
    public Transform shootingPoint;
    [SerializeField] float TimeBetweenShots;
    //
    public LayerMask layermask;

    [SerializeField] Transform castPosition;
    [SerializeField] float detectionDistance;
    [SerializeField] float baseCastDistance;

    public GameObject DetectionPoint;

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
        if (Health <= 0) Destroy(gameObject);
        RaycastHit2D enemy;
        if (facingDirection == LEFT) {
            enemy = Physics2D.Raycast(DetectionPoint.transform.position, Vector2.right * new Vector2(-1, 0f), detectionDistance, layermask);
            if (enemy.collider != null)
            {
                Debug.DrawRay(DetectionPoint.transform.position, Vector2.right * enemy.distance * new Vector2(-1, 0f), Color.red);
                if (canShoot)
                {
                    Shoot();
                    canShoot = false;
                    ShootingDelay();
                }            
            }
            else
            {
                Debug.DrawRay(DetectionPoint.transform.position, Vector2.right * detectionDistance * new Vector2(-1, 0f), Color.green);
            }
        }
        else
        {
            enemy = Physics2D.Raycast(DetectionPoint.transform.position, Vector2.right * new Vector2(1, 0f), detectionDistance, layermask);
            if (enemy.collider != null)
            {
                Debug.DrawRay(DetectionPoint.transform.position, Vector2.right * enemy.distance * new Vector2(1, 0f), Color.red);
                if (canShoot)
                {
                    Shoot();
                    canShoot = false;
                    ShootingDelay();
                }
            }
            else
            {
                Debug.DrawRay(DetectionPoint.transform.position, Vector2.right * detectionDistance * new Vector2(1, 0f), Color.green);
            }

        }


    }
    private void ShootingDelay()
    {
        if (crLimit == 0) {
            StartCoroutine(Delay());
        }
        
    }
    IEnumerator Delay()
    {
        crLimit++;
        yield return new WaitForSeconds(TimeBetweenShots);
        canShoot = true;
        crLimit--;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.Health -= CollisionDamage;

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

    void Shoot()
    {
        Debug.Log("ajjajj lõni kéne");
        GameObject si = Instantiate(projectile, shootingPoint);
        si.transform.parent = null;
        
        
    }

    public void TakeDamage(float damageValue) { 
        Health -= damageValue;
    }

   
}
