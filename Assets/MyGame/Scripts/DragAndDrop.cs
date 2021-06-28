using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragAndDrop : UIElement
{
    private Camera cam;
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;
    private float distance;

    private void Awake()
    {
        cam = Camera.main;
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            distance = Vector3.Distance(transform.position, cam.transform.position);
            currentDrag = StartCoroutine(Drag(raycaster, eventSystem, cam, distance));
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(currentDrag);
        }
    }
}
