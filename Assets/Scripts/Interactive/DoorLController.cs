using UnityEngine;
using UnityEngine.EventSystems;

public class DoorLController : MonoBehaviour, IPointerClickHandler
{  
    public bool OpenL;

    public void OnPointerClick(PointerEventData data)
    {
        if(OpenL)
        {
            CloseDoorL();
        }
        else 
        {
            OpenDoorL();
        }
    }

    public void OpenDoorL()
    {
        gameObject.transform.Rotate(0, 50, 0);
        OpenL = true;
    }  

   
    public void CloseDoorL()
    {
        gameObject.transform.Rotate(0, -50, 0);
        OpenL = false;
    }
}
