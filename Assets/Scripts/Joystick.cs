using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform handleReference;
    public RectTransform joystickHolder;
    public float joystickRange;
    public Vector2 dragDirection;

    public Vector2 movementDirection;

    public void OnDrag(PointerEventData eventData)
    {
        //Vector2 anchoredFromCenter = new Vector2(eventData.position.x / Screen.width, eventData.position.y / Screen.height);
        dragDirection = eventData.position - joystickHolder.anchoredPosition;
        movementDirection = dragDirection.normalized;

        handleReference.anchoredPosition = Vector2.ClampMagnitude(dragDirection, joystickRange);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Pressed Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Released");
        movementDirection = Vector2.zero;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
