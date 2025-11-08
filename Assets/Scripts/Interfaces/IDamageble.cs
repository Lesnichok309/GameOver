public interface IDamageble
{
    public float MaxHealth { get; set;}
    public float Health { get;}
    public void TakeDamage(float damage);
    public void TakeHeal(float heal);
    public void Die();
}
/*
    public float MaxHealth
    {
        get { return maxHealth; }
        set
        {
            if (value > 0)
                maxHealth = value;
        }
    }
    
    public float Health
    {
        get { return health ;}
    }
*/
