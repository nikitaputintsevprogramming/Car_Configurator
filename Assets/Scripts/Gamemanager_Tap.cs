using UnityEngine;
using UnityEngine.UI;

public class Gamemanager_Tap : MonoBehaviour
{
    public GameObject panel_start;

    void Start()
    {
        panel_start = FindObjectOfType<Image>().gameObject;
        panel_start.SetActive(true);
    }

    void OnMouseDown() 
    {
        print(panel_start.transform.position);
        panel_start.SetActive(false);
    }    
}
