using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float attackRange = 5f;
    public Transform attackPoint;
    public float attackRadius = .5f;
    public LayerMask attackLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, transform.position)<= attackRange){
            RandomAttackAnimation();
        }
    }

    void RandomAttackAnimation(){
        int randomAttack = Random.Range(0,2);
        if(randomAttack == 0){
            animator.SetTrigger("Attack1");
    }else{
        animator.SetTrigger("Attack2");
    }

    public void Attack(){
        Collider2D collInfo = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackLayer);
        //if(collInfo){

        //}
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
        if(attackPoint ==  null){
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
}
