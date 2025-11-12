 #if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

public class EnemyController : MonoBehaviour
{
    public EnemyConstructor myEnemyConstructor;

    private List<Type> MoveComponents = new List<Type>()
    {
        typeof(BaseMoveBot),
        //typeof(EazyEnemy)
    };

    public void AddEnemySkills()
    {
        Debug.Log($"Add new enemy Skills");
        if (Application.isPlaying) return; // избегаем во время игры

        if (myEnemyConstructor == null)
        {
            RemoveComponentIfExists(typeof(BaseDamageble));
            RemoveComponentIfExists(MoveComponents);
            return;
        }

        if (myEnemyConstructor != null)
        {
            if (myEnemyConstructor.BaseDamageble)
                AddComponentIfMissing(typeof(BaseDamageble));
            else
                RemoveComponentIfExists(typeof(BaseDamageble));

            if (myEnemyConstructor.Move)
            {
                BotMoveType moveType = myEnemyConstructor.MoveType;
                switch (moveType)
                {
                    case BotMoveType.BaseMoveBot:
                        AddComponentFromList(typeof(BaseMoveBot), MoveComponents);

                        break;

                    case BotMoveType.EazyMoveBot:
                        AddComponentFromList(typeof(EazyEnemy), MoveComponents);
                        break;
                }
            }
            else
                RemoveComponentIfExists(MoveComponents);
        }
    }

    void AddComponentIfMissing(Type needType)
    {
        var comp = GetComponent(needType);
        if (comp == null)
        {
            if (typeof(Component).IsAssignableFrom(needType))
                UnityEditor.Undo.AddComponent(gameObject, needType);
            else
                 Debug.LogWarning($"Type {needType} cant be added."); 
        }
    }

    void RemoveComponentIfExists(Type needType)
    {
        var comp = GetComponent(needType);
        if (comp != null)
            Undo.DestroyObjectImmediate(comp);
        
    }

    void RemoveComponentIfExists(List<Type> typeList)
    {
        foreach (Type needType in typeList)
        {
            var comp = GetComponent(needType);
            if (comp != null)
                Undo.DestroyObjectImmediate(comp);
        }
    }

    void AddComponentFromList(Type needType,List<Type> typeList)
    {
       
        foreach (Type type in typeList)
        {
           
            if (type == needType)
            {
                
                AddComponentIfMissing(needType);
            }
            else
                RemoveComponentIfExists(type);
        }
    }
}
#endif