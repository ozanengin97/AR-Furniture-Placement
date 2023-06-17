using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checkout : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text textComponent;
    private int startCounter = 0;

    public void OpenPopup()
    {
        popupPanel.SetActive(true);
    }
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
    public void RunStartCode()
    {
        GameObject refComponent = GameObject.FindGameObjectWithTag("CheckoutTextComponent");
        TMP_Text tmpComponent = refComponent.GetComponent<TMP_Text>();
        tmpComponent.text = string.Empty;
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject clone in clones)
        {
            tmpComponent.text += " • "+clone.name.Substring(0,clone.name.Length-7).Replace("_", " ");
            tmpComponent.text += "\n";
        }
    }
}
