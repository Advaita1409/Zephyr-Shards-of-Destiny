using UnityEngine;

public class CameraFollowGround : MonoBehaviour
{
    public Transform ground; // Assign your ground object here
    public float heightOffset = 5f; // Adjust height offset as needed
    public float followSpeed = 5f; // Smooth following speed

    void Update()
    {
        // Target position for the camera
        Vector3 targetPosition = new Vector3(transform.position.x, ground.position.y + heightOffset, transform.position.z);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
