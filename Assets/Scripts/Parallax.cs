using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float parallaxEffect;
    private float startPos;
    private float length;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = this.transform.position.x;
        length = this.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance,0f,0f);
        float temp = cam.transform.position.x + (1-parallaxEffect);
        if(temp > startPos + length){
            startPos += length;
        }
    }
}
