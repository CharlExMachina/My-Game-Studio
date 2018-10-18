using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will generate random projects with names, costs and team requirements. Methods of this
/// class will return a new project instance that can be then consumed by other classes
/// </summary>
public class ProjectGenerator : MonoBehaviour
{
    [SerializeField] private GameTitleDatabase _database;

    /// <summary>
    /// Generates a batch of projects for the player
    /// </summary>
    /// <param name="batchSize">How many projects should be generated in the current batch</param>
    /// <returns>Returns a list containing the newly generated projects</returns>
    public List<Project> GenerateProjectsBatch(int batchSize)
    {
        var batch = new List<Project>();

        for (var i = 0; i < 10; i++)
        {
            var generatedProject = GenerateProject();
            batch.Add(generatedProject);
        }

        return batch;
    }

    private Project GenerateProject()
    {
        var newProject = new Project {Title = _database.GetRandomTitleFromDatabase()};
        newProject.Description = GenerateDescription(newProject.Title);
        newProject.Requirements.GiCost = GenerateProjectCost();
        newProject.Requirements.TimeToDevelop = GenerateTimeToDevelop();
        newProject.Requirements.RequiredMembers = GenerateRequiredMembers();

        return newProject;
    }

    private List<RequiredMembers> GenerateRequiredMembers()
    {
        var requiredProgrammers = new RequiredMembers(TeamMember.Department.Programming, 40, Random.Range(1, 4));
        var requiredArtists = new RequiredMembers(TeamMember.Department.Art, 50, 2);

        var finalList = new List<RequiredMembers> {requiredProgrammers, requiredArtists};
        return finalList;
    }

    private int GenerateTimeToDevelop()
    {
        return Random.Range(1, 15 + 1);
    }

    private int GenerateProjectCost()
    {
        return Random.Range(10000, 500000);
    }

    private string GenerateDescription(string gameTitle)
    {
        // TODO: Each project type will have a different description
        return "Video game project. The studio will develop the game " + gameTitle +
               ". The project will require members from the Programming, Art, Sound and" +
               " Marketing teams to be developed.";
    }

    // TODO: Write the new project into a file
}