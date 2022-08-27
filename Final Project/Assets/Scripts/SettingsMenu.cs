using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public GameObject settingsUI;

    void Start ()
    {
        // Adds computer's native resolutions to the list
        resolutions = Screen.resolutions;

        // Removes all the default options
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        // Adds all the new options
        int currentResolutionIndex = resolutions.Length;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);     // Adds options to the dropdown
        resolutionDropdown.value = currentResolutionIndex;      // Auto-selects resolution to computer's current resolution
        resolutionDropdown.RefreshShownValue();
    }

    void Update ()
    {
        // Closes screen if the user hits "Escape" to close the pause menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            settingsUI.SetActive(false);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        // Broken fullscreen button
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];   // Finds the resolution at the chosen index
        // Sets game resolution to the chosen resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        // Takes input from the slider to adjust the in-game audio mixer volume
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        // Changes graphics quality to desired quality
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
