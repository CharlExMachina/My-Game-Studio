using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudioStats : MonoBehaviour
{
    [SerializeField] private int _currentStudioGi; // The current amount of GI the player possesses
    [SerializeField] private float _studioPopularity; // A value that will determine how popular the studio is
    [HideInInspector] public List<TeamMember> TeamMembers;
    private Dictionary<TeamMember.Department, List<TeamMember>> _divisions;

    private void Start()
    {
        TeamMembers = FindObjectOfType<TeamMemberGenerator>().GenerateTeamMembers(15);
        InitializeDivisions();
        OrganizeTeamMembers(TeamMembers);
    }

    private void InitializeDivisions()
    {
        _divisions = new Dictionary<TeamMember.Department, List<TeamMember>>();
        _divisions[TeamMember.Department.Programming] = new List<TeamMember>();
        _divisions[TeamMember.Department.Art] = new List<TeamMember>();
        _divisions[TeamMember.Department.SoundDesign] = new List<TeamMember>();
        _divisions[TeamMember.Department.StudioDevelopment] = new List<TeamMember>();
        _divisions[TeamMember.Department.Marketing] = new List<TeamMember>();
    }

    private void OrganizeTeamMembers(List<TeamMember> teamMembers)
    {
        foreach (var teamMember in teamMembers)
        {
            // Find the highest value in a rank
            var departmentOfMaxValue = teamMember.Ranks.Keys.Aggregate((x, y) => teamMember.Ranks[x] > teamMember.Ranks[y] ? x : y);
            // Adds member to that division
            _divisions[departmentOfMaxValue].Add(teamMember);
        }

        //foreach (var division in _divisions)
        //{
        //    Debug.Log("DIVISION: " + division.Key);
        //    foreach (var member in division.Value)
        //    {
        //        Debug.Log(member.Name);
        //    }
        //}
    }

    public int GetStudioGi()
    {
        return _currentStudioGi;
    }

    public int GetNumberOfTotalMembers()
    {
        return TeamMembers.Count;
    }

    public List<TeamMember> GetCurrentTeam()
    {
        return TeamMembers;
    }

    public List<TeamMember> GetCurrentTeamByDivision(TeamMember.Department department)
    {
        return _divisions[department];
    }
}