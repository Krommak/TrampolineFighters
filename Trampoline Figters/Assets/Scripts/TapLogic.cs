using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapLogic : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Transform playerTransform;
    private float start;
    private bool isRotate;
    private float startPlayer;
    public void OnBeginDrag(PointerEventData eventData)
    {
        start = Input.mousePosition.y;
        startPlayer = playerTransform.eulerAngles.x;
        isRotate = true;
    }

    private void FixedUpdate()
    {
        if (isRotate)
        {
            playerTransform.Rotate(((Input.mousePosition.y - start) * Time.deltaTime), 0, 0);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isRotate = false;
    }
}
