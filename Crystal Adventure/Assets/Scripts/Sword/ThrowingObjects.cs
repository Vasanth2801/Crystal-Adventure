using UnityEngine;

public class ThrowingObjects : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
