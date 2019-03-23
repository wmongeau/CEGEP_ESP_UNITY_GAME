using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametreControlleur : MonoBehaviour {
    [SerializeField]
    Dropdown drpGraphiques;

    [SerializeField]
    Dropdown drpResolutions;

    Resolution[] resolutions;

    bool pleinEcran;
    private void Start()
    {
        pleinEcran = Screen.fullScreen;
        drpGraphiques.value = QualitySettings.GetQualityLevel();
        resolutions = Screen.resolutions;
        drpResolutions.ClearOptions();
        List<string> optionsRes = new List<string>();
        int resolutionActuel = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            optionsRes.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionActuel = i;
            }
        }
        drpResolutions.AddOptions(optionsRes);
        drpResolutions.value = resolutionActuel;
        drpResolutions.RefreshShownValue();
    }
    public void ChangerGraphiques(int qualité)
    {
        QualitySettings.SetQualityLevel(qualité);
    }
    public void ChangerResolution(int resolution)
    {
        Resolution resolutionDesire = resolutions[resolution];

        Screen.SetResolution(resolutionDesire.width, resolutionDesire.height,pleinEcran);
    }
}
