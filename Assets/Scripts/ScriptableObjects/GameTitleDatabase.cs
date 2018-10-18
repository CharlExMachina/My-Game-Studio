using UnityEngine;

[CreateAssetMenu(fileName = "New Title Database", menuName = "Create Title Database", order = 1)]
public class GameTitleDatabase : ScriptableObject
{
    public string[] Titles;
    public string[] Subtitles;

    public string GetRandomTitleFromDatabase()
    {
        var title = GetRandomTitle();
        var subtitle = GetRandomSubtitle();

        return title + " " + subtitle;
    }

    private string GetRandomSubtitle()
    {
        var subtitle = Subtitles[Random.Range(0, Subtitles.Length)];
        return subtitle;
    }

    private string GetRandomTitle()
    {
        var randomTitle = Titles[Random.Range(0, Titles.Length)];
        return randomTitle;
    }
}