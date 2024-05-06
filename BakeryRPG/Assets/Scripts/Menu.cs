using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Menu", menuName = "New Menu/Menu")]
public class Menu : ScriptableObject
{
    public string menuName;
    public Sprite menuImage;
    public int piece;
    public int time;
    public int price;
    public List<Item> ingredients = new List<Item>();
}
