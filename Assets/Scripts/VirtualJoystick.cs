using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private float _joystickDistance = 100f;
    [SerializeField] private Image _joystickBackground;
    private RectTransform _backgroundRect;
    [SerializeField] private Image _joystick;
    private RectTransform _joystickRect;

    public Vector3 Direction { get; private set; }


    private void Start()
    {
        _backgroundRect = GetComponent<RectTransform>();
        _joystickRect = _joystick.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPosition = Vector2.zero;
        Camera camera = eventData.pressEventCamera;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundRect, eventData.position, camera, out localPosition))
        {
            Debug.Log($"[{GetType()}.{nameof(OnDrag)}] localPosition {{x : {localPosition.x}, y: {localPosition.y} }}!");

            localPosition.x = localPosition.x / _backgroundRect.sizeDelta.x;
            localPosition.y = localPosition.y / _backgroundRect.sizeDelta.y;

            Debug.Log($"[{GetType()}.{nameof(OnDrag)}] localPosition {{x : {localPosition.x}, y: {localPosition.y} }}");

            Vector2 backgroundPivot = _backgroundRect.pivot;

            Debug.Log($"[{GetType()}.{nameof(OnDrag)}] backgroundPivot {{x : {backgroundPivot.x}, y: {backgroundPivot.y} }}");

            localPosition.x += backgroundPivot.x - 0.5f;
            localPosition.y += backgroundPivot.y - 0.5f;

            Debug.Log($"[{GetType()}.{nameof(OnDrag)}] localPosition {{x : {localPosition.x}, y: {localPosition.y} }}");

            float x = Mathf.Clamp(localPosition.x, -1, 1);
            float y = Mathf.Clamp(localPosition.y, -1, 1);

            Direction = new Vector3(x, 0f, y).normalized;

            _joystickRect.anchoredPosition = new Vector3(Direction.x * _joystickDistance, 
                                                            Direction.z * _joystickDistance,
                                                                0f);

            Debug.Log(new string('=', 40));

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
