using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Desktop/Window/Dialog")]
public class Dialog : ScriptableObject
{
    public Sprite iconOnLeft;
    public string dialogText;
    public string[] buttons;
}
