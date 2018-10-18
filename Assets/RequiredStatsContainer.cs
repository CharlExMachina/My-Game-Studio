using TMPro;
using UnityEngine;

public class RequiredStatsContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _requiredStatLabel;
    [SerializeField] private TextMeshProUGUI _requiredStatValue;
    [SerializeField] private TextMeshProUGUI _currentStatLabel;

    public void RequirementToDisplay(string requirementLabel)
    {
        _requiredStatLabel.text = requirementLabel;
    }

    public void RequiredValueToDisplay(string requiredValueLabel)
    {
        _requiredStatValue.text = requiredValueLabel;
    }

    public void CurrentValueToDisplay(string currentValueLabel)
    {
        _currentStatLabel.text = currentValueLabel;
    }
}