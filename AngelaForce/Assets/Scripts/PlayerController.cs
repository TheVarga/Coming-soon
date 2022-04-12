using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.5f;
        jumpForce = 40f;
        isJumping = false;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);           
        }
        if (!isJumping && moveVertical > 0.1f) {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce),ForceMode2D.Impulse);
        }
        if(moveHorizontal > 0 && !facingRight){
            FlipCharacter();
        }
        if (moveHorizontal < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJumping = true;
        }
    }
    void FlipCharacter() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
