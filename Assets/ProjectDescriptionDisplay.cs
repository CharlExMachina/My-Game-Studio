using TMPro;
using UnityEngine;

public class ProjectDescriptionDisplay : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Display(string description)
    {
        _text.text = description;
    }
}