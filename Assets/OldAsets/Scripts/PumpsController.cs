using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PumpsController : MonoBehaviour
{
    public Camera cam;
    public float radius = 2;

    public Button[] interactButtons;
    
    void Start()
    {
        interactButtons = gameObject.GetComponentsInChildren<Button>();
    }
    
    void Update()
    {
        CheckInteract();
    }

    void CheckInteract()
    {
        foreach (Button interactButton in interactButtons)
        {
            
            interactButton.gameObject.transform.LookAt(-cam.transform.position);
            float dis = Vector3.Distance(cam.transform.position, interactButton.transform.position);
            if(dis <= radius)
            {
                interactButton.gameObject.SetActive(true);
            }        
            else
            {
                interactButton.gameObject.SetActive(false);
            }
        }
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(interactButton.gameObject.transform.position, radius);
    // }
}
