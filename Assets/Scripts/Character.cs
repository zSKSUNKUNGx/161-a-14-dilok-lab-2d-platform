using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField] private int maxHealth = 100;
    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            UpdateHealthBar(); // อัปเดต bar ทุกครั้งที่เลือดเปลี่ยน
        }
    }

    protected Animator anim;
    protected Rigidbody2D rb;
    protected HealthBar healthBar; // 🎯 ตัวแปรอ้างถึง HealthBar

    // ===== Initialize =====
    public void Initialize(int startHealth)
    {
        maxHealth = startHealth;
        Health = startHealth;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // 🔗 หา HealthBar ที่เป็นลูกของ GameObject นี้
        healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth, Health);
        }

        Debug.Log($"{this.name} initial Health: {this.Health}");
    }

    // ===== Take Damage =====
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage! Current Health: {Health}");

        if (IsDead())
        {
            OnDeath();
        }
    }

    // ===== Heal =====
    public void Heal(int amount)
    {
        Health += amount;
        Debug.Log($"{this.name} healed {amount} HP! Current Health: {Health}");
    }

    // ===== Death Check =====
    public bool IsDead()
    {
        return Health <= 0;
    }

    protected virtual void OnDeath()
    {
        Debug.Log($"{this.name} is dead and destroyed!");
        Destroy(this.gameObject);
    }

    // ===== Update HealthBar =====
    private void UpdateHealthBar()
    {
        if (healthBar != null)
            healthBar.UpdateHealth(Health);
    }
}
