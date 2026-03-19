using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "Desktop Theme")]
public class Theme : ScriptableObject
{
    public Color windowColour;
    public bool titleBarIsGradient;
    public Color titleBarColour1;
    public Color titleBarColour2;
}
