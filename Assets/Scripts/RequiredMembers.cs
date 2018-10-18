using System.Collections.Generic;
using System.Linq;

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
        //var qualifiedMembers = new List<TeamMember>(_requiredMembers.Capacity);

        //for (var i = 0; i < qualifiedMembers.Capacity; i++)
        //{
        //    if (members[i].GetRank(_department) >= _minRank)
        //    {
        //        qualifiedMembers.Add(members[i]);
        //    }
        //}

        var numberOfRequiredMembers = _requiredMembers.Capacity;
        var currentNumberOfQualifiedMembers = members.Count;

        return currentNumberOfQualifiedMembers == numberOfRequiredMembers;

        //_requiredMembers = qualifiedMembers;

        //return qualifiedMembers.Count == qualifiedMembers.Capacity; // If there are enough members, it will return true
    }

    /// <summary>
    /// Checks a list of team members and return the quantity of qualified members (if any)
    /// </summary>
    /// <param name="currentStaff">A list containing team members to start checking if they are qualified</param>
    /// <returns>Returns the number of qualified staff the player possesses</returns>
    public int GetNumberOfCurrentQualifiedMembers(List<TeamMember> currentStaff)
    {
        var qualifiedMembers =
            from m in currentStaff
            where m.GetRank(_department) >= _minRank
            select m;

        var qualifiedMembersList = qualifiedMembers.ToList();

        return qualifiedMembersList.Count;
    }

    public TeamMember.Department GetRequiredDepartment()
    {
        return _department;
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