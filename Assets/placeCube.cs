using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeCube : MonoBehaviour
{
    private GameObject kup;
    private duzlem halka;
    // Start is called before the first frame update
    void Start()
    {
        halka = FindObjectOfType<duzlem>();
        //kup = GameObject.CreatePrimitive(PrimitiveType.Cube);
        kup = GameObject.Find("Armchair_406_Artek");
        //kup.transform.localScale = new Vector3(0.1f,0.1f,0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase==TouchPhase.Began)
        {
            GameObject go = Instantiate(kup,halka.transform.position,halka.transform.rotation);
            go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // scaling
        }
    }
}
