using System.Collections.Generic;

/// <summary>
/// This class displays the required members for a specific project, and also checks
/// if the Studio has enough members to fulfill the requirement.
/// </summary>
public class RequiredMembers
{
    private List<TeamMember> _requiredMembers;
    private readonly int _minRank;
    private readonly TeamMember.Department _department;

    public RequiredMembers(TeamMember.Department department, int minRank, int requiredAmt)
    {
        _requiredMembers = new List<TeamMember>(requiredAmt);
        _department = department;
        _minRank = minRank;
    }

    public bool CheckIfStudioHasEnoughMembers(List<TeamMember> members)
    {
        var qualifiedMembers = new List<TeamMember>(_requiredMembers.Capacity);

        for (var i = 0; i < qualifiedMembers.Capacity; i++)
        {
            if (members[i].GetRank(_department) >= _minRank)
            {
                qualifiedMembers.Add(members[i]);
            }
        }

        _requiredMembers = qualifiedMembers;

        return qualifiedMembers.Count == qualifiedMembers.Capacity; // If there are enough members, it will return true
    }

    public int GetNumberOfCurrentQualifiedMembers()
    {
        return _requiredMembers.Count;
    }

    public int GetNumberOfRequiredMembers()
    {
        return _requiredMembers.Capacity;
    }

    public List<TeamMember> GetAcceptedMembers()
    {
        return _requiredMembers;
    }
}