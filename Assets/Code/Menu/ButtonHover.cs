using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    private Image targetImage;
    [SerializeField]
    private Color originalColor;
    [SerializeField]
    private Color hoverColor;
    [SerializeField]
    private bool selected;

    public void Awake()
    {
        if(selected) GetComponent<Button>().Select();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Button>().Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        targetImage.color = hoverColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        targetImage.color = originalColor;
    }
}
