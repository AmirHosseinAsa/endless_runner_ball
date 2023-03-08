using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.Rendering.PostProcessing.PostProcessLayer;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionsPanel;
    [SerializeField] GameObject VisualsPanel;
    [SerializeField] GameObject SoundsPanel;
    [SerializeField] PostProcessLayer PostProcessLayer;
    [SerializeField] GameObject StartMenu;

    [SerializeField] Light Light;
    public Slider LightLevel;

    public Slider AmbienceLevel;
    public Slider SFXLevel;
    public AudioMixer AmbienceMixer;
    public AudioMixer SFXMixer;

    public GameObject PauseFirstButton;
    public GameObject PlayButton;
    bool PlaySelected = false;

    void Start()
    {
        var menuData = SaveSystem.LoadMenuOptionSettings();
        if (menuData != null)
        {

            LightLevel.value = menuData.LightLevel;
            Light.intensity = LightLevel.value;

            AmbienceLevel.value = menuData.AmbienceLevel;
            SFXLevel.value = menuData.SFXLevel;
            ChangeSoundVolume();
        }

        OptionsPanel.SetActive(false);
        SwichOffAllPanels();
        VisualsPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (SaveScript.IsItFirstTimeRunning && !PlaySelected)
        {
            SaveScript.IsOptionsPanelActive = false;
            Cursor.visible = true;
            Time.timeScale = .5f;
            Cursor.lockState = CursorLockMode.None;
            StartMenu.SetActive(true);
            OptionsPanel.SetActive(false);

            //Clear selected object
            EventSystem.current.SetSelectedGameObject(null);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(PlayButton);

            PlaySelected = true;

        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) && (!SaveScript.IsItFirstTimeRunning))
         {
            VisualsPanel.SetActive(false);
            SoundsPanel.SetActive(false);

            SaveScript.IsOptionsPanelActive = !SaveScript.IsOptionsPanelActive;

            if (!SaveScript.IsOptionsPanelActive) SaveSystem.SaveMenuSettings(new MenuSettingsData( LightLevel.value,  AmbienceLevel.value, SFXLevel.value));

            Time.timeScale = SaveScript.IsOptionsPanelActive ? 0f : 1f;
            Cursor.visible = SaveScript.IsOptionsPanelActive;
            Cursor.lockState = SaveScript.IsOptionsPanelActive ? CursorLockMode.None : CursorLockMode.Locked;
            OptionsPanel.SetActive(SaveScript.IsOptionsPanelActive);
            VisualsPanel.SetActive(SaveScript.IsOptionsPanelActive);

            //Clear selected object
            EventSystem.current.SetSelectedGameObject(null);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(PauseFirstButton);
        }
    }
    public void ChangeLightValue()
    {
        Light.intensity = LightLevel.value;
    }
    void SwichOffAllPanels()
    {
        VisualsPanel.SetActive(false);
        SoundsPanel.SetActive(false);
    }
    public void ChangeSoundVolume()
    {
        //Expose Parameter
        AmbienceMixer.SetFloat("Volume", AmbienceLevel.value);
        SFXMixer.SetFloat("Volume", SFXLevel.value);
    }

    public void ChangeActivePanel(string panelTitle)
    {
        SwichOffAllPanels();
        switch (panelTitle)
        {
            case "VisualsPanel":
                VisualsPanel.SetActive(true);
                break;
            case "SoundsPanel":
                SoundsPanel.SetActive(true);
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Play":
                SaveScript.IsItFirstTimeRunning = false;
                SaveScript.IsOptionsPanelActive = false;
                Cursor.visible = false;
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                StartMenu.SetActive(false);
                OptionsPanel.SetActive(false);
                break;
        }
    }
}
