using Player;
using UnityEditor;
using UnityEngine;


namespace Player.Editor
{
[CustomEditor(typeof(PlayerStats))]
    public class PlayerStatsEditor : UnityEditor.Editor
    {
        private PlayerStats StatsTarget => target as PlayerStats;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Reset Player"))
            {
                StatsTarget.ResetPlayer();
                EditorUtility.SetDirty(StatsTarget);
            }
        }
    }
}