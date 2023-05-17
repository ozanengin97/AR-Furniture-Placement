using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObject : MonoBehaviour
{
    public void deleteProcess ()
    {
        if (OutlineSelection.selectedObject != null && OutlineSelection.selectedObject.CompareTag("Selected"))
        {
            //Destroy(go.transform.gameObject);
            Destroy(OutlineSelection.selectedObject.gameObject);
            //placeCube.diningChairCreated = false;
            OutlineSelection.selectedObject = null;
        }
    }
}
