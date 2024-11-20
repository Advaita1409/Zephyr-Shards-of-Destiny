using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float jumpHeight= 10f;
    private bool isGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1f,0f) * Time.deltaTime * moveSpeed);
        if(Input.GetKey(KeyCode.Space) && isGround == true){
            Jump();
            isGround = false;
        }
    }

    void Jump(){
        Vector2 velocity= rb.linearVelocity;
        velocity.y = jumpHeight;
        rb.linearVelocity= velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            isGround == true;
        }
    }
}

