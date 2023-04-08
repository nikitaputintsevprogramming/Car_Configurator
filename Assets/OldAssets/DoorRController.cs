using UnityEngine;
using UnityEngine.EventSystems;

namespace Interactive
{
    public class DoorRController : MonoBehaviour, IPointerClickHandler
    {  
        public bool openR;

        public void OnPointerClick(PointerEventData data)    
        {        
            if(openR)
            {
                CloseDoorR();
            }
            else 
            {
                OpenDoorR();
            }
        }

        private void OpenDoorR()
        {
            gameObject.transform.Rotate(0, -50, 0);
            openR = true;
        }


        private void CloseDoorR()
        {
            gameObject.transform.Rotate(0, 50, 0);
            openR = false;
        }
    }
}
