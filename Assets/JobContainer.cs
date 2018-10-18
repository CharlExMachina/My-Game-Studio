using UnityEngine;
using UnityEngine.EventSystems;

public class JobContainer : MonoBehaviour, ISelectHandler
{
    private AudioSource _audioSource;
    private ProjectManager _projectManager;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _projectManager = FindObjectOfType<ProjectManager>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        _audioSource.Play();
        TransferJobDescription();
        FindObjectOfType<NavigationScroll>().Scroll();
    }

    private void TransferJobDescription()
    {
        var index = transform
            .GetSiblingIndex(); // Gets the index of the current container. These are in the same order as the project list, so it works.

        FindObjectOfType<ProjectDescriptionDisplay>()
            .Display(_projectManager.GetProject(index).Description);

        FindObjectOfType<DisplayRequiredStats>().Display(_projectManager.GetProject(index).Requirements);
    }
}