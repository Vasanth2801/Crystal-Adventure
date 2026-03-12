using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("UI Reference")]
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = (float) currentHealth/maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            currentHealth = 0;
            Destroy(gameObject);
            Destroy(healthBar);
        }
    }
}