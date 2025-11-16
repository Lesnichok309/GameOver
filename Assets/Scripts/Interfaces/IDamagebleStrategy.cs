public interface IDamagebleStrategy
{
    public int MaxHealth { get; set;}
    public int Health { get;}
    public void TakeDamage(int damage);
    public void TakeHeal(int heal);
    public void Die();

    public void NewInit(int newMaxHealth){}
}

