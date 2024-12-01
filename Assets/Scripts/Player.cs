using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float jumpHeight= 10f;
    private bool isGround = true;
    public Animator animator;
    public Transform attackPoint;
    public float attackRadius =1f;
    public LayerMask attackLayer;
    public int maxHealth = 3;
    public GameObject explosionPrefab;

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
            animator.SetBool("Jump", true);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            AttackAnimation();
        }
    }

    void AttackAnimation(){
        animator.SetTrigger("Attack");
    }
    void Jump(){
        Vector2 velocity= rb.linearVelocity;
        velocity.y = jumpHeight;
        rb.linearVelocity= velocity;
    }

    public void Attack(){
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackLayer);
        if(hit == true){
            hit.GetComponent<Enemy1>().TakeDamage(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }

    public void TakeDamage(int damage){
        if(maxHealth<=0){
            return;
        }
        maxHealth -= damage;
    }

    private void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }


    void Die(){
        GameObject tempEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(tempEffect, 0.501f);
        Destroy(this.gameObject);
    }
}

