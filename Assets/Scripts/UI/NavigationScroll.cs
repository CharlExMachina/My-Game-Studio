using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NavigationScroll : MonoBehaviour
{
    private RectTransform _scrollRectTransform;
    private RectTransform _contentPanel;
    private RectTransform _selectedRectTransform;
    private GameObject _lastSelected;

    private void Start()
    {
        _scrollRectTransform = GetComponent<RectTransform>();
        _contentPanel = GetComponent<ScrollRect>().content;

        GetComponent<ScrollRect>().verticalNormalizedPosition = 0.0f;
    }

    public void Scroll()
    {
        // Get the currently selected UI element from the event system.
        var selected = EventSystem.current.currentSelectedGameObject;

        // Return if there are none.
        if (selected == null)
        {
            return;
        }

        // Return if the selected game object is not inside the scroll rect.
        if (selected.transform.parent != _contentPanel.transform)
        {
            return;
        }

        // Return if the selected game object is the same as it was last frame,
        // meaning we haven't moved.
        if (selected == _lastSelected)
        {
            return;
        }

        // Get the rect transform for the selected game object.
        _selectedRectTransform = selected.GetComponent<RectTransform>();
        // The position of the selected UI element is the absolute anchor position,
        // ie. the local position within the scroll rect + its height if we're
        // scrolling down. If we're scrolling up it's just the absolute anchor position.
        var selectedPositionY =
            Mathf.Abs(_selectedRectTransform.anchoredPosition.y) + _selectedRectTransform.rect.height;

        // The upper bound of the scroll view is the anchor position of the content we're scrolling.
        var scrollViewMinY = _contentPanel.anchoredPosition.y;
        // The lower bound is the anchor position + the height of the scroll rect.
        var scrollViewMaxY = _contentPanel.anchoredPosition.y + _scrollRectTransform.rect.height;

        // If the selected position is below the current lower bound of the scroll view we scroll down.
        if (selectedPositionY > scrollViewMaxY)
        {
            var newY = selectedPositionY - _scrollRectTransform.rect.height + 55;
            _contentPanel.anchoredPosition = new Vector2(_contentPanel.anchoredPosition.x, newY);
        }
        // If the selected position is above the current upper bound of the scroll view we scroll up.
        else if (Mathf.Abs(_selectedRectTransform.anchoredPosition.y) < scrollViewMinY)
        {
            _contentPanel.anchoredPosition = new Vector2(_contentPanel.anchoredPosition.x,
                Mathf.Abs(_selectedRectTransform.anchoredPosition.y + 55));
        }

        _lastSelected = selected;
    }
}