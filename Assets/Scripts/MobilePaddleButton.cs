using UnityEngine;
using UnityEngine.EventSystems;

public class MobilePaddleButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerExitHandler
{
    [SerializeField] private bool moveUp;
    [SerializeField] private RectTransform buttonRect;

    private void Awake()
    {
        buttonRect = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Finger press/hold hua
        Vector2 direction = moveUp ? Vector2.up : Vector2.down;

        PaddleMovement.instance.SetMobileDirection(direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PaddleMovement.instance.SetMobileDirection(Vector2.zero);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PaddleMovement.instance.SetMobileDirection(Vector2.zero);
    }
    public void OnDrag(PointerEventData eventData)
    {
        bool fingerInsideButton =
            RectTransformUtility.RectangleContainsScreenPoint(
                buttonRect,
                eventData.position,
                eventData.pressEventCamera
            );

        if (!fingerInsideButton)
        {
            StopPaddle();
        }
    }

    private void StopPaddle()
    {
        PaddleMovement.instance.SetMobileDirection(Vector2.zero);

    }
}