#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // ваши стандартные поля

        EnemyController script = (EnemyController)target;

        if (GUILayout.Button("AddEnemySkills"))
        {
            script.AddEnemySkills();
        }
    }
}
#endif