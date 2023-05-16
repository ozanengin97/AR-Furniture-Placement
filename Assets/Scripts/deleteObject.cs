using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    public void deleteProcess ()
    {
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && diningChairCreated == true)
        //{
            //Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            //RaycastHit hit;
            
            //if (Physics.Raycast(ray, out hit))
            //{
                //if (OutlineSelection.selectedObject.CompareTag("Selected"))
                //{
                    //Destroy(go.transform);
                    //diningChairCreated = false; 
                //}
            //}
        //}
            if (placeCube.diningChairCreated && OutlineSelection.selectedObject != null && OutlineSelection.selectedObject.CompareTag("Selected"))
            {
                //Destroy(go.transform.gameObject);
                Destroy(OutlineSelection.selectedObject.gameObject);
                placeCube.diningChairCreated = false;
                OutlineSelection.selectedObject = null;
            }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
