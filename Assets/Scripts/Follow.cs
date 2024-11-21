using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    public float smoothNess = 2f;
    // Update is called once per frame
    private void FixedUpdate(){
        Vector3 targetPosition = new Vector3(player.position.x,transform.position.y,transform.position.z);
        transform.position = Vector3.Slerp(transform.position, targetPosition, smoothNess*Time.deltaTime) ;
    }
}
