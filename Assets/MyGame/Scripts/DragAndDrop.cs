using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera cam;
    private Coroutine currentDrag;
    private float distance;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            distance = Vector3.Distance(transform.position, cam.transform.position);
            currentDrag = StartCoroutine(Drag());
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(currentDrag);
        }
    }

    private IEnumerator Drag()
    {
        while (true)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);

            transform.position = rayPoint;
            yield return null;
        }
    }
}
