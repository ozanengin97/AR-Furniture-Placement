using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeCube : MonoBehaviour
{
    private GameObject kup;
    private duzlem halka;
    private bool diningChairCreated;
    private float speedModifier;
    private Vector3 translationVector;
    GameObject go;

    private float previousRotationAngle;
    private float currentRotationAngle;
    private float rotationSpeed;

    //Object scaling animation
    IEnumerator LerpObjectScale(Vector3 a, Vector3 b, float time, GameObject lerpObject)
    {
        float i = 0.0f;
        float rate = (1.0f / time);
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            lerpObject.transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
    void Start()
    {
        diningChairCreated = false;
        halka = FindObjectOfType<duzlem>();
        //kup = GameObject.CreatePrimitive(PrimitiveType.Cube);
        kup = Resources.Load<GameObject>("Dining_Chair");

    }
    void Update()
    {
        
        //Add process
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && diningChairCreated == false)
        {
            go = Instantiate(kup, halka.transform.position, halka.transform.rotation);
            go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // first small
            StartCoroutine(LerpObjectScale(go.transform.localScale, new Vector3(0.9f, 0.9f, 0.9f), 1.0f, go)); // than animation starting, getting bigger.
            diningChairCreated = true; 
            //go.tag = "Selected";
        }
        speedModifier = 0.0005f;

       // Object movement logic within the Update function
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved && kup != null)
        {
            if (OutlineSelection.selectedObject != null && OutlineSelection.selectedObject.CompareTag("Selected"))
            {
                // Convert X-Y touch movement to object translation in world space
                translationVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
                OutlineSelection.selectedObject.transform.Translate(translationVector * Input.GetTouch(0).deltaPosition.y * speedModifier, Space.World);

                translationVector = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z);
                OutlineSelection.selectedObject.transform.Translate(translationVector * Input.GetTouch(0).deltaPosition.x * speedModifier, Space.World);
            }
        }

        //Object rotation
        previousRotationAngle = 0f;
        currentRotationAngle = 0f;
        rotationSpeed = 2.5f;
        // Initialize rotation angle for 2-finger object rotation
        previousRotationAngle = currentRotationAngle;
        // Check if user is touching with 2 finger and is not touching any UI
        if (Input.touchCount == 2)
        {
            if (OutlineSelection.selectedObject != null && OutlineSelection.selectedObject.CompareTag("Selected"))
            {
                currentRotationAngle = Mathf.Atan((Input.GetTouch(0).position.y - Input.GetTouch(1).position.y) / (Input.GetTouch(0).position.x - Input.GetTouch(1).position.x));
                if ((currentRotationAngle - previousRotationAngle) > 0)
                {
                    OutlineSelection.selectedObject.transform.Rotate(0, rotationSpeed, 0);
                }
                if ((currentRotationAngle - previousRotationAngle) < 0)
                {
                    OutlineSelection.selectedObject.transform.Rotate(0, rotationSpeed, 0);
                }
            }
        }

        // //Delete process
        // else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && diningChairCreated == true)
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        //     RaycastHit hit;
            
        //     Debug.Log("1. kisim");
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         Debug.Log("2. kisim");
        //         Debug.Log(hit.collider.name);
        //         if (hit.collider.CompareTag("Selectable"))
        //         {
        //             Debug.Log("3. kisim");
        //             Destroy(hit.collider.gameObject);
        //             diningChairCreated = false; 
        //         }
        //     }
        // }
        //Outline effect
        // if (Input.GetTouch(0).phase == TouchPhase.Ended)
        // { 
        //     Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //     RaycastHit raycastHit;
        //     if (Physics.Raycast(raycast, out raycastHit))
        //     {
        //         if (raycastHit.collider.CompareTag("Object"))
        //         {
        //             HighlightObject();
        //         }
        //     }
        //     else { DeselectObject(); }
        // }
        // else { DeselectObject(); }
    }
}
