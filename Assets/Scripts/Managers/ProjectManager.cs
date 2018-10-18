using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectManager : MonoBehaviour
{
    [SerializeField] private List<Project> _availableProjects;

    private Project _selectedProject;
    private ProjectGenerator _projectGenerator;
    private StudioStats _studioStats;

    private void Start()
    {
        _studioStats = FindObjectOfType<StudioStats>();
        _projectGenerator = FindObjectOfType<ProjectGenerator>();
        _availableProjects = _projectGenerator.GenerateProjectsBatch(5);
    }

    public void SetSelectedProject(Project project)
    {
        _selectedProject = project;
        GameObject.Find("Start Development Button").GetComponent<Button>().interactable = CanBeDeveloped();
    }

    public List<Project> GetProjects()
    {
        return _availableProjects;
    }

    public Project GetProject(int index)
    {
        return _availableProjects[index];
    }

    public void StartProject()
    {
        // TODO: Take the necessary team members for the project
        // TODO: Take the GI from the player
        // TODO: Start a timer
        // TODO: After project is finished, return the utilized team members to their respective division
    }

    private bool CanBeDeveloped()
    {
        foreach (var requiredMembers in _selectedProject.Requirements.RequiredMembers)
        {
            // If the studio doesn't have enough members...
            if (!requiredMembers.CheckIfStudioHasEnoughMembers(
                _studioStats.GetCurrentTeamByDivision(requiredMembers.GetRequiredDepartment())))
            {
                return false;
            }
        }

        // If the studio doesn't have enough GI
        if (_studioStats.GetStudioGi() < _selectedProject.Requirements.GiCost)
        {
            return false;
        }

        return true;
    }
}