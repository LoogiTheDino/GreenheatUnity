using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines the icons sprite, name and window to open 
[CreateAssetMenu(fileName = "Icon", menuName = "Desktop/Icon/Normal")]
public class Icon : ScriptableObject
{
    public Sprite bigIconSprite;
    public Sprite iconSprite;
    public Sprite smallIconSprite;
    public string iconName;
    public bool isShortcut;
    public Window window;
}
