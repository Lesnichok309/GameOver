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
    private SerializedProperty Move;
    private SerializedProperty MoveType;
    private SerializedProperty Speed;
    private SerializedProperty DifAngle;
    //
    public void OnEnable()
    {
        BaseDamageble = serializedObject.FindProperty("BaseDamageble");
        maxHealthProp = serializedObject.FindProperty("MaxHealth");
        DieScore = serializedObject.FindProperty("DieScore");

        Move = serializedObject.FindProperty("Move");
        MoveType = serializedObject.FindProperty("MoveType");
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

        EditorGUILayout.PropertyField(Move);
        if (Move.boolValue)
        {
            EditorGUILayout.PropertyField(MoveType);    
            EditorGUILayout.PropertyField(Speed);
            EditorGUILayout.PropertyField(DifAngle);
        }

        // применяем изменения
        serializedObject.ApplyModifiedProperties();
    }
}
#endif

