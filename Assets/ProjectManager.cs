using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    private ProjectGenerator _projectGenerator;
    [SerializeField] private List<Project> _availableProjects;

    private void Start()
    {
        _projectGenerator = FindObjectOfType<ProjectGenerator>();
        _availableProjects = _projectGenerator.GenerateProjectsBatch(5);
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

    }
}