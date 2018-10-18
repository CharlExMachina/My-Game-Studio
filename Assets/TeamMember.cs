using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TeamMember
{
    public enum Department
    {
        Programming,
        Art,
        SoundDesign,
        StudioDevelopment,
        Marketing
    }

    public string Name;
    [HideInInspector] public bool ShowInEditor;
    public Dictionary<Department, int> Ranks;

    public TeamMember(string name, int programmingRank, int artRank, int soundDesignRank, int studioDevelopmentRank,
        int marketingRank)
    {
        Name = name;

        Ranks = new Dictionary<Department, int>
        {
            {Department.Programming, programmingRank},
            {Department.Art, artRank},
            {Department.SoundDesign, soundDesignRank},
            {Department.StudioDevelopment, studioDevelopmentRank},
            {Department.Marketing, marketingRank}
        };

    }

    /// <summary>
    /// Returns the rank value within a specific department
    /// </summary>
    /// <param name="key">The department you want to get the rank from</param>
    /// <returns></returns>
    public int GetRank(Department key)
    {
        return Ranks[key];
    }
}