using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    List<Item> items = new List<Item>();

    void Add(Item item)
    {
        items.Add(item);
    }
    void Remove(Item item)
    {
        if (items.Contains(item))
            items.Remove(item);
    }
}
