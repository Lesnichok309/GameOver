using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventSystemScript 
{
    public static UnityEvent<int> OnEnemyDie = new UnityEvent<int>();
    // Start is called before the first frame update
    public static void SendEnemyDie(int DieBonus)
    {
        OnEnemyDie.Invoke(DieBonus);
    }

}
