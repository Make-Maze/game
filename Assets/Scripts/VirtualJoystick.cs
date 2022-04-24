using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform stick;
    private RectTransform rect;
    private Vector2 rectTransform;

    [SerializeField, Range(10f, 150f)]
    private float stickRange;

    private Vector2 inputVector;
    private bool isInput;

    public PlayerMove playerMove;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        rectTransform = rect.position;
    }

    private void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //var inputDir = eventData.position - rectTransform;
        //Debug.Log(eventData.position +"-"+ rectTransform+"="+inputDir);
        //var clampedDir = inputDir.magnitude < stickRange ? inputDir : inputDir.normalized * stickRange;
        //stick.anchoredPosition = clampedDir;

        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //var inputDir = eventData.position - rectTransform;
        //Debug.Log(eventData.position + "-" + rectTransform + "=" + inputDir);
        //var clampedDir = inputDir.magnitude < stickRange ? inputDir : inputDir.normalized * stickRange;
        //stick.anchoredPosition = clampedDir;

        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform;
        //Debug.Log(inputDir);
        var clampedDir = inputDir.magnitude < stickRange ? inputDir : inputDir.normalized * stickRange;
        stick.anchoredPosition = clampedDir;
        inputVector = clampedDir / stickRange;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        stick.anchoredPosition = Vector2.zero;
        isInput = false;    
    }

    private void FixedUpdate()
    {
        if (isInput&&playerMove!=null)
        {
            //Debug.Log(inputVector.x + "/" + inputVector.y);
            playerMove.Move(inputVector);
        }
    }
}
