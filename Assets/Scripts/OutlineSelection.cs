using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    public static Transform selectedObject;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (!EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId) && Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
            {
                highlight = raycastHit.transform;
                if (highlight.CompareTag("Selectable") && highlight != selection)
                {
                    if (highlight.gameObject.GetComponent<Outline>() != null)
                    {
                        highlight.gameObject.GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        Outline outline = highlight.gameObject.AddComponent<Outline>();
                        outline.enabled = true;
                        highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                        highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                    }
                }
                else
                {
                    highlight = null;
                }
            }
        }
        // Selection
        else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform.CompareTag("Selectable"))
                {
                    if (selection != null)
                    {
                        selection.gameObject.tag = "Selectable";
                        selection.gameObject.GetComponent<Outline>().enabled = false;
                    }
                    selection = raycastHit.transform;
                    selection.gameObject.tag = "Selected";
                    selection.gameObject.GetComponent<Outline>().enabled = true;
                    selectedObject = selection; // burada değişkeni güncelliyoruz
                    highlight = null;
                }
                else
                {
                    if (selection)
                    {
                        selection.gameObject.tag = "Selectable";
                        selection.gameObject.GetComponent<Outline>().enabled = false;
                        selection = null;
                    }
                    selectedObject = null; // burada değişkeni null yapıyoruz
                }
            }
        }
    }
}
