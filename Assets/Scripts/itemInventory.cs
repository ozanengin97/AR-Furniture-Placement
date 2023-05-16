using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInventory : MonoBehaviour
{
    public void item_1()
    {
        placeCube.kup = Resources.Load<GameObject>("Armchair");
    }
    public void item_2()
    {
        placeCube.kup = Resources.Load<GameObject>("Coffee_Table");
    }
    public void item_3()
    {
        placeCube.kup = Resources.Load<GameObject>("Coffee_Table_2");
    }
    public void item_4()
    {
        placeCube.kup = Resources.Load<GameObject>("Dining_Chair");
    }
    public void item_5()
    {
        placeCube.kup = Resources.Load<GameObject>("Floor_Light");
    }
    public void item_6()
    {
        placeCube.kup = Resources.Load<GameObject>("Plant");
    }
    public void item_7()
    {
        placeCube.kup = Resources.Load<GameObject>("Rug_140x200cm");
    }
    public void item_8()
    {
        placeCube.kup = Resources.Load<GameObject>("Rug_High_Pile_Grey");
    }
    public void item_9()
    {
        placeCube.kup = Resources.Load<GameObject>("Sofa");
    }
    public void item_10()
    {
        placeCube.kup = Resources.Load<GameObject>("Table");
    }
}
