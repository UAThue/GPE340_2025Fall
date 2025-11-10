using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class UI_Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle isFullScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetResolutionOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetResolutionOptions ()
    {
        // Store the chosen value index
        int chosenIndex = 0;

        // Make a list of strings of our different resolutions
        List<string> resolutionStrings = new List<string>();
        for (int i = 0; i< Screen.resolutions.Length; i++ ) 
        {
            Resolution resolution = Screen.resolutions[i];

            string resolutionString = $"{resolution.width} x {resolution.height} ({resolution.refreshRateRatio})";
            resolutionStrings.Add(resolutionString);   

            // If our current resolution is this resolution, set our dropdown to this value
            if (resolution.width == Screen.currentResolution.width 
                && resolution.height == Screen.currentResolution.height)
            {
                chosenIndex = i;
            }
        }

        // Clear out the dropdown and fill it with OUR strings
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutionStrings);

        // Set our selection to our chosen index
        resolutionDropdown.value = chosenIndex;

        // Set our toggle based on the current resolution
        isFullScreen.isOn = Screen.fullScreen;

    }

    public void OnSettingsChange()
    {
        // Apply screen resolutions
        Screen.SetResolution(Screen.resolutions[resolutionDropdown.value].width,
                             Screen.resolutions[resolutionDropdown.value].height,
                             isFullScreen.isOn);
    }

}
