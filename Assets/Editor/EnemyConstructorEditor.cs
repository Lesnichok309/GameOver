#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyConstructor))]
public class EnemyConstructorEditor : Editor
{
    // Health
    private SerializedProperty BaseDamageble;

    private SerializedProperty maxHealthProp;
    private SerializedProperty HealthProp;
    private SerializedProperty DieScore;
    //

    // Move
    private SerializedProperty BaseMoveBot;

    private SerializedProperty Speed;
    private SerializedProperty DifAngle;
    //
    public void OnEnable()
    {
        BaseDamageble = serializedObject.FindProperty("BaseDamageble");
        maxHealthProp = serializedObject.FindProperty("MaxHealth");
        DieScore = serializedObject.FindProperty("DieScore");

        BaseMoveBot = serializedObject.FindProperty("BaseMoveBot");
        Speed = serializedObject.FindProperty("Speed");
        DifAngle= serializedObject.FindProperty("DifAngle");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Отрисовка переключателя
        EditorGUILayout.PropertyField(serializedObject.FindProperty("EnemyName"));
        
        // При значении true показываем поле, при false — скрываем
        EditorGUILayout.PropertyField(BaseDamageble);
        if (BaseDamageble.boolValue)
        {
            EditorGUILayout.PropertyField(maxHealthProp);
            EditorGUILayout.PropertyField(DieScore);
        }

        EditorGUILayout.PropertyField(BaseMoveBot);
        if (BaseMoveBot.boolValue)
        {
            EditorGUILayout.PropertyField(Speed);
            EditorGUILayout.PropertyField(DifAngle);
        }

        // применяем изменения
        serializedObject.ApplyModifiedProperties();
    }
}
#endif

