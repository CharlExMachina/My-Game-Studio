using System;
using UnityEngine;

public class DisplayRequiredStats : MonoBehaviour
{
    [SerializeField] private RequiredStatsContainer _containerPrefab;
    [SerializeField] private RequiredStatsContainer _containerSansCurrent;

    public void Display(ProjectRequirements requirements)
    {
        //Clear the container from old requirements
        foreach (Transform container in transform)
        {
            Destroy(container.gameObject);
        }


        var giCostContainer = Instantiate(_containerPrefab, transform);
        giCostContainer.RequirementToDisplay("GI");
        giCostContainer.RequiredValueToDisplay(requirements.GiCost.ToString());
        giCostContainer.CurrentValueToDisplay(FindObjectOfType<StudioStats>().GetStudioGi().ToString());

        var timeContainer = Instantiate(_containerSansCurrent, transform);
        timeContainer.RequirementToDisplay("Time");
        timeContainer.RequiredValueToDisplay(requirements.TimeToDevelop + " minutes");

        foreach (var member in requirements.RequiredMembers)
        {
            var container = Instantiate(_containerPrefab, transform);
            container.RequirementToDisplay(GetDepartmentName(member.GetRequiredDepartment()));
            container.RequiredValueToDisplay("X " + member.GetNumberOfRequiredMembers());
            container.CurrentValueToDisplay(member
                .GetNumberOfCurrentQualifiedMembers(FindObjectOfType<StudioStats>().GetCurrentTeamByDivision(member.GetRequiredDepartment())).ToString());
        }
    }

    private string GetDepartmentName(TeamMember.Department department)
    {
        switch (department)
        {
            case TeamMember.Department.Programming:
                return "Programmer";
            case TeamMember.Department.Art:
                return "Artist";
            case TeamMember.Department.SoundDesign:
                return "Sound Designer";
            case TeamMember.Department.StudioDevelopment:
                return "Studio Development Staff";
            case TeamMember.Department.Marketing:
                return "Marketing Staff";
            default:
                throw new ArgumentOutOfRangeException("department", department, null);
        }
    }
}