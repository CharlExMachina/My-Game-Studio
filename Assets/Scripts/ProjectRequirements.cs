using System;
using System.Collections.Generic;

[Serializable]
public class ProjectRequirements
{
    public int GiCost;
    public int TimeToDevelop;

    public List<RequiredMembers> RequiredMembers;
}
