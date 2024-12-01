using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float attackRange = 5f;
    public Transform attackPoint;
    public float attackRadius = 0.5f;
    public LayerMask attackLayer;
    public int maxHealth =2;
    public GameObject explosionPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Update()
    {
        if(Object.FindFirstObjectByType<GameManager>().isGameActive == false){
            return;
        }
        if(maxHealth<=0){
            Die();
        }
        if (Vector2.Distance(player.position, transform.position) <= attackRange)
        {
            RandomAttackAnimation();
        }
    }

    public void RandomAttackAnimation()
    {
        int randomAttack = Random.Range(0, 2);
        if (randomAttack == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else
        {
            animator.SetTrigger("Attack2");
        }
    }

    // This function is now correctly placed
    public void Attack()
    {
        Collider2D collInfo = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackLayer);
        if(collInfo){
            collInfo.GetComponent<Player>().TakeDamage(1);
        }
        // Handle collision logic here
    }

    public void TakeDamage(int damage){
        if(maxHealth <=0){
            return;
        }
        maxHealth -= damage;
    }

    // Ensure this is outside other methods
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        if (attackPoint == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
    void Die(){
        GameObject tempExplosionEffect = Instantiate(explosionPrefab,transform.position, Quaternion.identity);
        Destroy(tempExplosionEffect, 1f);
        Destroy(this.gameObject);
    }
}
