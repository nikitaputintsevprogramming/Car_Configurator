using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public GameObject cam;
    public CameraController _cameraController;    
    public GameObject PanelSettings;

    public List<Slider> sliders = new List<Slider>();
    public List<Text> perTexts = new List<Text>();

    public List<float> controllerValues = new List<float>();

    void Start()
    {        
        _cameraController = cam.GetComponent<CameraController>();
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
            _cameraController.sensitivity = sliders[0].value;
            _cameraController.zoomSpeed = sliders[1].value;
            _cameraController.DesktopSpeedDelta = sliders[2].value;
            _cameraController.yMinLimit = sliders[3].value;
            _cameraController.yMaxLimit = sliders[4].value;
            _cameraController.distanceMin = sliders[5].value;
            _cameraController.distanceMax = sliders[6].value;
        }
    }
}
