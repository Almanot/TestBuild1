using UnityEngine;

public class Item : ScriptableObject
{
    new private string name = "New Item";
    bool isStackable = false;
    bool activated = false;
    bool usable = false;
    bool worn = false;
}
