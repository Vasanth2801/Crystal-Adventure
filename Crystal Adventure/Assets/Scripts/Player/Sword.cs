using UnityEngine;

public class Sword : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float swordForce = 10f;

    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private Animator animator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            ThrowSword();
        }
    }

    void ThrowSword()
    {
        animator.SetTrigger("Sword");
        GameObject sword = pooler.SpawnFromPools("Sword",firePoint.position,firePoint.rotation);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * swordForce, ForceMode2D.Impulse);
    }
}