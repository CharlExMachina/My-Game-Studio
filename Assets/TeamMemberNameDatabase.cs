using UnityEngine;

[CreateAssetMenu(fileName = "New Names Database", menuName = "Create Names Database", order = 1)]
public class TeamMemberNameDatabase : ScriptableObject
{
    [SerializeField] private string[] FirstNames;
    [SerializeField] private string[] LastNames;

    public string GetRandomNameFromDatabase()
    {
        var title = GetRandomFirstName();
        var subtitle = GetRandomLastName();

        return title + " " + subtitle;
    }

    private string GetRandomLastName()
    {
        var randomLastName = LastNames[Random.Range(0, LastNames.Length)];
        return randomLastName;
    }

    private string GetRandomFirstName()
    {
        var randomFirstName = FirstNames[Random.Range(0, FirstNames.Length)];
        return randomFirstName;
    }
}