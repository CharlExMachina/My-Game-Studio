using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will display a list of projects to a GUI object. The list will have to be
/// shown inside of a scrollable view. Entries of the list will be created in base of a prefab.
/// </summary>
public class AvailableProjectsDisplay : MonoBehaviour
{
    private List<Project> _availableProjects;

    private void Start()
    {
        _availableProjects = new List<Project>();

        // TODO: Get new Projects added by the project generator from an external file
    }
}