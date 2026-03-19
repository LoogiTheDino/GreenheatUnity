using UnityEngine;
using UnityEngine.UI;

public class IconScript : MonoBehaviour
{
    public Icon icon;
    public Window window;
    public Image iconImage;
    public Text iconText;

    public string iconName;
    public GameObject windowObj;
    GameObject clonedWindow;
    GameObject canvas;
    bool isOpened = false;

    public bool isShortcut;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>().gameObject;
    }

    public void DefineIcon(bool isInExplorer)
    {
        iconText.text = icon.iconName;
        iconImage.sprite = icon.iconSprite;
        if (isInExplorer)
        {
            iconText.color = Color.black;
        }
    }

    public void StartApp()
    {
        if (!isOpened)
        {
            isOpened = true;
            clonedWindow = Instantiate(windowObj, canvas.transform);
            clonedWindow.transform.SetSiblingIndex(1);
            clonedWindow.GetComponent<WindowScript>().icon = GetComponent<IconScript>();
            clonedWindow.GetComponent<WindowScript>().window = window;
            clonedWindow.GetComponent<WindowScript>().DefineWindow();

            ObjectDirectory.Instance.AddToList(clonedWindow.GetComponentInChildren<TitleBarScript>().GetComponent<RectTransform>());
            ObjectDirectory.Instance.AddToList(clonedWindow.GetComponentInChildren<WindowScript>().closeButton.GetComponent<RectTransform>());
        }
    }

    public void CloseApp()
    {
        isOpened = false;
    }
}
