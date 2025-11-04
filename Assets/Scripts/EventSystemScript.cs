
using UnityEngine.Events;

public static class EventSystemScript 
{
    public static UnityEvent<int> OnEnemyDie = new UnityEvent<int>();
    public static void SendEnemyDie(int DieBonus)
    {
        OnEnemyDie.Invoke(DieBonus);
    }

}
