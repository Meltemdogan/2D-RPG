using System;
using UnityEditor;
using UnityEngine;


namespace WayPoints.Editor
{
    [CustomEditor(typeof(WayPoint))]
    public class WayPointEditor : UnityEditor.Editor
    {
        private WayPoint wayPointTarget => target as WayPoint;
        
        private void OnSceneGUI()
        {
            if (wayPointTarget.Points.Length <= 0f) return;
            Handles.color = Color.red;
            for (int i = 0; i <wayPointTarget.Points.Length; i++)
            {
                EditorGUI.BeginChangeCheck();
                Vector3 currentPoint = wayPointTarget.EntityPosition + wayPointTarget.Points[i];
                
                Vector3 newPosition = Handles.FreeMoveHandle(currentPoint, 0.5f, Vector3.one* 0.5f, Handles.SphereHandleCap);
                
                GUIStyle text = new GUIStyle();
                text.fontStyle = FontStyle.Bold;
                text.fontSize = 16;
                text.normal.textColor = Color.black;
                Vector3 textPos = new Vector3(0.2f, -0.2f);
                Handles.Label(wayPointTarget.EntityPosition + wayPointTarget.Points[i] + textPos, $"{i+1}", text);
                
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "Free Move");
                    wayPointTarget.Points[i] = newPosition - wayPointTarget.EntityPosition;
                }
            }
            
        }
    }
}