using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageble , IMove
{
    [SerializeField] Transform target;
    [SerializeField]protected float difAngle;
    [SerializeField]protected float Health ;
    [SerializeField]protected float MaxHealth;
    [SerializeField] protected float Speed;
    [SerializeField]protected float dieScore;
    void Start()
    {
        if (MaxHealth <= 0)
        {
            MaxHealth = 1;
            Debug.LogError("Forgot to assign a MaxHealth value",transform);
        }
        Health = MaxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Health -= damage;
            if (Health <= 0)
            Die();
                
        }
    }
    public virtual void TakeHeal(float heal)
    {
        if (heal >= 0)
        {
            Health += heal;
        }
        if (Health > MaxHealth) Health = MaxHealth;
    }
    public virtual float GetHealth()
    {
        return Health;
    }
    public virtual void Die()
    {
        
    }
    public virtual void Move(){}
    public virtual void RotateToTarget() { }
    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
