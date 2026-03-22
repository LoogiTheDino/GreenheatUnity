using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
#if UNITY_EDITOR
    //This would add the object into the scene and put it as a child to the desktop canvas
    [MenuItem("GameObject/UI/Window")]
    public static void AddWindow()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultObjects/WindowTemplete"));
        obj.transform.parent = ThemeManager.instance.ui.transform;
    }
#endif
    //variables for defining the window.
    RectTransform rect;

    public Window window;

    public Image titleBarIcon;
    public Text titleBarText;

    public GameObject taskbarObject;
    public IconScript icon;

    //public bool isDialog;

    [HideInInspector]
    public bool minimised;
    [HideInInspector]
    public bool maximised;

    [Space]
    public bool canClose = true;

    //public Image maximiseButton;
    //public Image minimiseButton;
    public Image closeButton;
    [Space]
    public GameObject ExplorerArea;

    public void DefineWindow()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(window.windowLength, window.windowHeight);

        titleBarIcon.sprite = window.icon;
        titleBarText.text = window.titleBarText;
        if (window.GetType() == typeof(Explorer))
        {
            Explorer contents = (Explorer)window;
            GameObject[] explorerIcons = new GameObject[contents.icons.Count];

            ExplorerArea.SetActive(true);
            for (int i = 0; i < contents.icons.Count; i++)
            {
                explorerIcons[i] = Instantiate(ObjectDirectory.Instance.iconPrefab, ExplorerArea.transform);
                explorerIcons[i].GetComponent<IconScript>().window = null;
                explorerIcons[i].GetComponent<IconScript>().icon = contents.icons[i];
                explorerIcons[i].GetComponent<IconScript>().DefineIcon(true);

            }
        }
    }

    public void CloseWindow()
    {
        if (canClose)
        {
            ObjectDirectory.Instance.RemoveFromList(closeButton.GetComponent<RectTransform>());
            ObjectDirectory.Instance.RemoveFromList(GetComponentInChildren<TitleBarScript>().GetComponent<RectTransform>());

            if (icon != null) icon.CloseApp();

            Destroy(gameObject);
        }
    }
}
