using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checkout : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text textComponent = null;

    public void OpenPopup()
    {
        popupPanel.SetActive(true);
    }
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
    void Start()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject clone in clones)
        {
            textComponent.text += " • "+clone.name.Substring(0,clone.name.Length-7).Replace("_", " ");
            textComponent.text += "\n";
        }
    }
}
