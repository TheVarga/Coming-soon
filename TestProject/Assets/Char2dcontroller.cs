
using UnityEngine;


public class Char2dcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 15;
    public float JumpForce = 10;
    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
       var movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;

       if(Input.GetButtonDown("Jump")  && Mathf.Abs(_rigidbody.velocity.y) < 0.0001f ){
           _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
       }
    }

}
