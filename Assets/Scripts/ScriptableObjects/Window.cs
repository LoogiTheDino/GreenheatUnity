using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Window", menuName = "Desktop/Window/Normal")]
public class Window : ScriptableObject
{
    public int windowLength = 204;
    public int windowHeight = 204;

    //public int titleBarHeight = 18;

    public Sprite icon;
    public string titleBarText;

    public bool canAdjustSize;
}
