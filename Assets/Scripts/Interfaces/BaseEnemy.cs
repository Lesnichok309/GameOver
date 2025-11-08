using UnityEngine;

public abstract class BaseEnemy : BaseDamageble, IMove
{
    [SerializeField]protected Transform target;
    [SerializeField]protected float difAngle;
    [SerializeField]protected float Speed;
    [SerializeField] protected float dieScore;
    
    void Start()
    {
        if (maxHealth <= 0)
        {
            maxHealth = 1;
            Debug.LogError("Forgot to assign a MaxHealth value",transform);
        }
        health = maxHealth;
    }
   
    public virtual void Move(){}
    public virtual void RotateToTarget() { }
    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
