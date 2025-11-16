
using UnityEngine;

public enum BotMoveType
{
    BaseMoveBot,CircleMoveBot
}

[CreateAssetMenu(fileName = "NewEnemyConstructor", menuName = "EnemyConstructor")]
public class EnemyConstructor : ScriptableObject
{
    public string EnemyName = "Enemy";

    [Header("Health")]
    public bool BotDamagable = true;
    
    public int MaxHealth = 10;
    public int DieScore = 1;


    [Header("Move")]
    public bool Move;
    public BotMoveType MoveType = BotMoveType.BaseMoveBot;
    public float Speed = 5;
    public float DifAngle = 0;
    
   
}
