
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemyConstructor", menuName = "EnemyConstructor")]
public class EnemyConstructor : ScriptableObject
{
    public string EnemyName = "Enemy";

    [Header("Health")]
    public bool BaseDamageble = true;
    
    public int MaxHealth = 10;
    public int DieScore = 1;


    [Header("Move")]
    public bool BaseMoveBot;
    public float Speed = 5;
    public float DifAngle = 0;
    
   
}
