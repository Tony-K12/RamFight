using UnityEngine;

public class RamCombat : MonoBehaviour
{
    public RamCombat opponent;
    public HealthBar healthBar;
    public RamAnimatorController animatorController;

    [Header("Stats")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Combat Timing")]
    private float attackTimer;

    [Header("Start Delay")]
    public float startDelay = 2f; // Delay before fighting starts

    public bool isAlive = true;
    private bool fightStarted = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        animatorController.PlayIdle();

        // Start delay before fight begins
        Invoke(nameof(BeginFight), startDelay);
    }

    private void BeginFight()
    {
        fightStarted = true;
        attackTimer = Random.Range(1f, 2f); // initialize after delay
    }

    private void Update()
    {
        if (!isAlive || opponent == null || !opponent.isAlive || !fightStarted) return;

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0f)
        {
            attackTimer = Random.Range(1f, 2f); // for 10–20s total fight
            animatorController.PlayAttack(); // attack anim triggers DealDamage via event
        }
    }

    // Called by animation event
    public void DealDamage()
    {
        if (opponent == null || !opponent.isAlive) return;

        float damage = Random.Range(5f, 10f);
        bool isCrit = Random.value < 0.2f;
        if (isCrit) damage *= 2f;

        opponent.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        DamagePopup.Create(transform.position + Vector3.up * 1.5f, damage);

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            Die();
        }
        else
        {
            animatorController.PlayHit();
        }
    }

    private void Die()
    {
        isAlive = false;
        animatorController.PlayDeath();
        GameManager.Instance.DeclareWinner(this == GameManager.Instance.ramA ? "Ram B" : "Ram A");
    }
}
