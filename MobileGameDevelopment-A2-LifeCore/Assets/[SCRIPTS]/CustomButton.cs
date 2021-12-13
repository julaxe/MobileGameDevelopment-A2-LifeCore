using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : Button
{
    private UnityEvent mouseDown = new UnityEvent();
    private UnityEvent mouseUp = new UnityEvent();
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        mouseDown.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        mouseUp.Invoke();
    }

    public UnityEvent OnDown()
    {
        return mouseDown;
    }

    public UnityEvent OnUp()
    {
        return mouseUp;
    }
}
