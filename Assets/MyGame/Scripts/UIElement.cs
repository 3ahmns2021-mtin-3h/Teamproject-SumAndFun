using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIElement : MonoBehaviour
{
    protected static Coroutine currentDrag = null;

    protected IEnumerator Drag(GraphicRaycaster raycaster, EventSystem eventSystem, Camera cam, float distance)
    {
        while (true)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            List<RaycastResult> results = new List<RaycastResult>();

            PointerEventData pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;
            raycaster.Raycast(pointerEventData, results);

            foreach (var result in results)
            {
                if (result.gameObject == gameObject)
                {
                    transform.position = rayPoint;
                }
            }

            yield return null;
        }
    }
}
