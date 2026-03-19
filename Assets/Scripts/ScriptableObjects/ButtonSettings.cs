using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Desktop/Button")]
public class ButtonSettings : ScriptableObject
{
    public int buttonWidth = 75;
    public int buttonHeight = 23;

    public string buttonText;
}
