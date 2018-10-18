using UnityEngine;

public class DisplayRequiredStats : MonoBehaviour
{
    [SerializeField] private RequiredStatsContainer _containerPrefab;

    public void Display(ProjectRequirements requirements)
    {
        //Clear the container from old requirements
        foreach (Transform container in transform)
        {
            Destroy(container.gameObject);
        }


        var giCostContainer = Instantiate(_containerPrefab, transform);
        giCostContainer.RequirementToDisplay("GI");
        giCostContainer.RequiredValueToDisplay(requirements.GiCost.ToString());
        giCostContainer.CurrentValueToDisplay(FindObjectOfType<StudioStats>().GetStudioGi().ToString());
    }
}