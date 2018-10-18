using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StudioStats))] [CanEditMultipleObjects]
public class StudioStatsEditor : Editor
{
    private StudioStats _currentInstance;

    private void OnEnable()
    {
        _currentInstance = serializedObject.targetObject as StudioStats;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (_currentInstance.TeamMembers.Count > 0)
        {
            foreach (var teamMember in _currentInstance.TeamMembers)
            {
                EditorGUILayout.LabelField("Team member " + (_currentInstance.TeamMembers.IndexOf(teamMember) + 1), new GUIStyle {fontSize = 14, fontStyle = FontStyle.Bold});
                EditorGUILayout.LabelField("Member stats: ", new GUIStyle { fontStyle = FontStyle.Bold});
                EditorGUILayout.LabelField("Member name: " + teamMember.Name);
                EditorGUILayout.LabelField("Programming Rank " + teamMember.GetRank(TeamMember.Department.Programming));
                EditorGUILayout.LabelField("Art Rank " + teamMember.GetRank(TeamMember.Department.Art));
                EditorGUILayout.LabelField("Sound Design Rank " + teamMember.GetRank(TeamMember.Department.SoundDesign));
                EditorGUILayout.LabelField("Studio Development Rank " + teamMember.GetRank(TeamMember.Department.StudioDevelopment));
                EditorGUILayout.LabelField("Marketing Rank " + teamMember.GetRank(TeamMember.Department.Marketing));
            }
        }
    }
}