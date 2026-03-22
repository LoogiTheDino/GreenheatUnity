using UnityEngine;
using UnityEngine.InputSystem;

public class AdminSettings : MonoBehaviour
{
    public GameObject AdminInterface;
    public GameObject AdminButton;
    [Space]
    public GameObject ThemeTab;
    public GameObject LaunchAppsTab;
    public GameObject GeneralTab;
    public GameObject AboutTab;
    public GameObject CloseAppTab;
    public enum OpenTab { Themes, LaunchApps, General, About, Close };
    public OpenTab openTab;
    [Space]
    [Header("Desktop Related")]
    public GameObject desktopIcons;
    public GameObject pongUI;
    public GameObject pongGame;
    public GameObject paintUI;
    public GameObject paint;
    public GameObject hockeyUI;
    public GameObject hockeyGame;
    public GameObject circleNinja;
    public GameObject circleNinjaUI;
    public GameObject solitaire;
    public GameObject solitaireUI;

    Vector2 mousePosition;
    bool adminButtonOn;
    

    bool IsMouseOverScreen()
    {
        Vector3 mp = Input.mousePosition;
        return mp.x >= 0 && mp.y >= 0 && mp.x <= Screen.width && mp.y <= Screen.height;
    }

    private void Awake()
    {
        CloseInterface();
    }

    public void Update()
    {
        if (IsMouseOverScreen() && !adminButtonOn)
        {
            AdminButton.SetActive(true);
            adminButtonOn = true;
        }
        else if (!IsMouseOverScreen())
        {
            AdminButton.SetActive(false);
            adminButtonOn = false;
        }
    }

    public void ShowButton()
    {
        AdminButton.SetActive(true);
    }

    public void HideButton()
    {
        AdminButton.SetActive(false);
    }

    public void OpenInterface()
    {
        AdminInterface.SetActive(true);
        OpenLaunchAppsTab();
    }

    public void CloseInterface()
    {
        AdminInterface.SetActive(false);
    }

    public void OpenThemesTab()
    {
        CloseTab();
        openTab = OpenTab.Themes;
        ThemeTab.SetActive(true);
    }

    public void OpenLaunchAppsTab()
    {
        CloseTab();
        openTab = OpenTab.LaunchApps;
        LaunchAppsTab.SetActive(true);
    }

    public void OpenGeneralTab()
    {
        CloseTab();
        openTab = OpenTab.General;
        GeneralTab.SetActive(true);
    }

    public void CloseTab()
    {
        if (openTab == OpenTab.Themes) ThemeTab.SetActive(false);
        else if (openTab == OpenTab.LaunchApps) LaunchAppsTab.SetActive(false);
        else if (openTab == OpenTab.General) GeneralTab.SetActive(false);
        else if (openTab == OpenTab.About) AboutTab.SetActive(false);
        else if (openTab == OpenTab.Close) CloseAppTab.SetActive(false);
    }

    public void PongButton()
    {
        CloseInterface();
        //Launch Pong Interface
        desktopIcons.SetActive(false);
        pongUI.SetActive(true);
        pongGame.SetActive(true);
    }

    public void PaintButton()
    {
        CloseInterface();
        //Launch Paint Interface
        desktopIcons.SetActive(false);
        paint.SetActive(true);
    }

    public void HockeyButton()
    {
        CloseInterface();
        //Launch Hockey Interface
        desktopIcons.SetActive(false);
        hockeyGame.SetActive(true);
        hockeyUI.SetActive(true);
    }

    public void CircleNinjaButton()
    {
        CloseInterface();
        //Launch Circle Ninja Interface
        desktopIcons.SetActive(false);
        circleNinja.SetActive(true);
        circleNinjaUI.SetActive(true);
    }

    public void ClosePongApp()
    {
        pongUI.SetActive(false);
        pongGame.SetActive(false);
        desktopIcons.SetActive(true);
    }

    public void OpenAboutPage()
    {
        CloseTab();
        openTab = OpenTab.About;
        AboutTab.SetActive(true);
    }

    public void OpenShutdownPage()
    {
        CloseTab();
        openTab = OpenTab.Close;
        CloseAppTab.SetActive(true);
    }

    public void Shutdown()
    {
        Application.Quit();
    }
}