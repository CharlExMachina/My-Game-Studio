using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class will display a list of projects to a GUI object. The list will have to be
/// shown inside of a scrollable view. Entries of the list will be created in base of a prefab.
/// </summary>
public class AvailableProjectsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _projectListingPrefab;
    
    private List<Project> _projectsToDisplay;
    private ProjectManager _projectManager;

    private void Start()
    {
        _projectManager = FindObjectOfType<ProjectManager>();
        _projectsToDisplay = _projectManager.GetProjects();
        Display();
    }

    /// <summary>
    /// This method will instantiate a project entry prefab and then add it to the projects listing in the
    /// "Develop Project" menu.
    /// </summary>
    private void Display()
    {
        foreach (var project in _projectsToDisplay)
        {
            var instance = Instantiate(_projectListingPrefab, transform);
            instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = project.Title;
        }

        transform.GetChild(0).GetComponent<Button>().Select();
    }
}