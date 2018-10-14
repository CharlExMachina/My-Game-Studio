using UnityEngine;

public class StudioStats : MonoBehaviour
{
    [SerializeField] private float _currentStudioGi; // The current amount of GI the player possesses
    [SerializeField] private float _studioPopularity; // A value that will determine how popular the studio is

    private int _totalTeamMembers; // The whole sum of team members currently working in the studio

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}