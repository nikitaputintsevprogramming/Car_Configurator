using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public CameraController _cameraController;    
    public GameObject PanelSettings;

    public List<Slider> sliders = new List<Slider>();
    public List<Text> perTexts = new List<Text>();

    void Start()
    {

    }
    
    void Update()
    {
        SettingsValues();
    }

    void SettingsValues()
    {
        for (int count = 0; count < perTexts.Count; count++)
        {
            perTexts[count].text = sliders[count].value.ToString() + "%";
        }
        // TextPerSensivityComp.text = SliderSensivityComp.value.ToString() + "%";
        // TextPerZoomSpeedComp.text = SliderZoomSpeedComp.value.ToString() + "%";
        // TextPerDesktopDeltaComp.text = SliderDesktopDeltaComp.value.ToString() + "%";
        // TextPerDownLimitComp.text = SliderDownLimitComp.value.ToString() + "%";
        // TextPerUpLimitComp.text = SliderUpLimitComp.value.ToString() + "%";
        // TextPerMinDistanceComp.text = SliderMinDistanceComp.value.ToString() + "%";
        // TextPerMaxDistanceComp.text = SliderMaxDistanceComp.value.ToString() + "%";
    }
}
