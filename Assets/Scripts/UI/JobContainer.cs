using UnityEngine;
using UnityEngine.EventSystems;

public class JobContainer : MonoBehaviour, ISelectHandler
{
    private AudioSource _audioSource;
    private ProjectManager _projectManager;
    private Project _currentlySelectedProject;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _projectManager = FindObjectOfType<ProjectManager>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _audioSource.Play();

        UpdateCurrentlySelectedProject();
        TransferJobDescription();
        FindObjectOfType<NavigationScroll>().Scroll();
    }

    private void UpdateCurrentlySelectedProject()
    {
        // Gets the index of the current container. These are in the same order as the project list, so it works.
        var index = transform.GetSiblingIndex();
        _currentlySelectedProject = _projectManager.GetProject(index);
        _projectManager.SetSelectedProject(_currentlySelectedProject);
    }

    private void TransferJobDescription()
    {
        FindObjectOfType<ProjectDescriptionDisplay>()
            .Display(_currentlySelectedProject.Description);
        FindObjectOfType<DisplayRequiredStats>().Display(_currentlySelectedProject.Requirements);
    }
}