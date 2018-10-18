using System;

[Serializable]
public class Project
{
    public string Title;
    public string Description;
    public ProjectRequirements Requirements;

    public Project()
    {
        Requirements = new ProjectRequirements();
    }
}