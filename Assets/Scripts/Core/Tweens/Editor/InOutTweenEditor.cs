using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InOutTween))]
public class InOutTweenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InOutTween tween = (InOutTween)target;

        GUILayout.Space(10);
        EditorGUILayout.LabelField("Editor Controls", EditorStyles.boldLabel);

        if (GUILayout.Button("💾 Save as Start Position"))
        {
            tween.SaveAsStart();
        }

        if (GUILayout.Button("💾 Save as End Position"))
        {
            tween.SaveAsEnd();
        }

        GUI.enabled = Application.isPlaying;
        if (GUILayout.Button("▶ Move In (Play Mode Only)"))
        {
            tween.MoveIn();
        }
        GUI.enabled = true;
    }
}
