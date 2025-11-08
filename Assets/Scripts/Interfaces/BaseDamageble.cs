using UnityEngine;

public class BaseDamageble : MonoBehaviour,IDamageble
{
    [SerializeField]protected float health ;
    [SerializeField]protected float maxHealth;
    
    public float MaxHealth
    {
        get { return maxHealth; }
        set
        {
            if (value > 0)
                maxHealth = value;
        }
    }
    public float Health { get { return health; } }
    
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
    public virtual void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            health -= damage;
            if (health <= 0)
            Die();
        }
    }
    public virtual void TakeHeal(float heal)
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
