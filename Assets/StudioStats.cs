using System.Collections.Generic;
using UnityEngine;

public class StudioStats : MonoBehaviour
{
    [SerializeField] private int _currentStudioGi; // The current amount of GI the player possesses
    [SerializeField] private float _studioPopularity; // A value that will determine how popular the studio is
    [SerializeField] public List<TeamMember> TeamMembers;

    private int _totalTeamMembers; // The whole sum of team members currently working in the studio

    public int GetStudioGi()
    {
        return _currentStudioGi;
    }
}