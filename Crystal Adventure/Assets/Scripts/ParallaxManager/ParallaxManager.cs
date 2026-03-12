using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    private float startPos;
    private float length;
    public GameObject newCamera;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void LateUpdate()
    {
        float distance = newCamera.transform.position.x * parallaxEffect;
        float movement = newCamera.transform.position.x * (1 - parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y,transform.position.z);

        if(movement > startPos + length)
        {
            startPos += length;
        }
        else if(movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
