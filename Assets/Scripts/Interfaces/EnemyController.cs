using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyController : MonoBehaviour
{
    public EnemyConstructor myEnemyConstructor;

    public void AddEnemySkills()
    {
        Debug.Log("Change");
        #if UNITY_EDITOR
        if (Application.isPlaying) return; // избегаем во время игры

        if (myEnemyConstructor == null)
        {
            RemoveComponentIfExists<BaseDamageble>();
            RemoveComponentIfExists<BaseMoveBot>();
            return;
        }

        // Предполагается, что EnemyConstructor имеет публичные bool поля Move и Damage
        if (myEnemyConstructor != null)
        {
            if (myEnemyConstructor.BaseDamageble)
                AddComponentIfMissing<BaseDamageble>();
            else
                RemoveComponentIfExists<BaseDamageble>();

            if (myEnemyConstructor.BaseMoveBot)
                AddComponentIfMissing<BaseMoveBot>();
            else
                RemoveComponentIfExists<BaseMoveBot>();
        }
        #endif
    }

    void AddComponentIfMissing<T>() where T : Component
    {
        if (GetComponent<T>() == null)
        {
            #if UNITY_EDITOR
            UnityEditor.Undo.AddComponent<T>(this.gameObject);
            #endif
        }
    }

    void RemoveComponentIfExists<T>() where T : Component
    {
        var comp = GetComponent<T>();
        if (comp != null)
        {
            #if UNITY_EDITOR
            Undo.DestroyObjectImmediate(comp);
            #endif
        }
    }
}


