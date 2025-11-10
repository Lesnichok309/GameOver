using UnityEngine;

public class BaseDamageble : MonoBehaviour, IDamageble
{
    [Header("Health")]
    [SerializeField]protected int health ;
    [SerializeField]protected int maxHealth;
    
    public int MaxHealth
    {
        get { return maxHealth; }
        set
        {
            if (value > 0)
                maxHealth = value;
        }
    }
    public int Health { get { return health; } }
    
    void Start()
    {
        if (maxHealth <= 0)
        {
            maxHealth = 1;
            Debug.LogError("Forgot to assign a MaxHealth value", transform);
            return;
        }
        health = maxHealth;
    }
    public virtual void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            health -= damage;
            if (health <= 0)
            Die();
        }
    }
    public virtual void TakeHeal(int heal)
    {
        if (heal >= 0)
        {
            health += heal;
        }
        else
        {
            Debug.LogError("An use TakeHeal with a negative value");
            return;
        }
        if (health > maxHealth) health = maxHealth;
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
   
}
