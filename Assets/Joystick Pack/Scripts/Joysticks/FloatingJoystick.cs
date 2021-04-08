using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private float _widthBottomBound; 
    private float _widthUpperBound;
    private float _heightBottomBound;
    private float _heightUpperBound; 


    protected override void Start()
    {
        base.Start();
        //background.gameObject.SetActive(false);

        _widthBottomBound = background.sizeDelta.x / 2;
        _widthUpperBound = Screen.width - _widthBottomBound;

        _heightBottomBound = background.sizeDelta.y / 2;
        _heightUpperBound = Screen.height - _heightBottomBound;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        //background.gameObject.SetActive(true);
        eventData.position = HoldInScreenBoundaries(eventData.position);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }

    private Vector2 HoldInScreenBoundaries(Vector2 position)
    {
        position.x = Mathf.Clamp(position.x, _widthBottomBound, _widthUpperBound);
        position.y = Mathf.Clamp(position.y, _heightBottomBound, _heightUpperBound);
        
        return position;
    }
}