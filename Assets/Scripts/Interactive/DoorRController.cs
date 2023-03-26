using UnityEngine;
using UnityEngine.EventSystems;

public class DoorRController : MonoBehaviour, IPointerClickHandler
{  
    public bool OpenR;

    public void OnPointerClick(PointerEventData data)    
    {        
        if(OpenR)
        {
            CloseDoorR();
        }
        else 
        {
            OpenDoorR();
        }
    }

    public void OpenDoorR()
    {
        gameObject.transform.Rotate(0, -50, 0);
        OpenR = true;
    }  

   
    public void CloseDoorR()
    {
        gameObject.transform.Rotate(0, 50, 0);
        OpenR = false;
    }
}
