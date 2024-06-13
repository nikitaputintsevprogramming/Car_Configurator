using UnityEngine;
using UnityEngine.EventSystems;

namespace Interactive
{
    public class DoorLController : MonoBehaviour, IPointerClickHandler
    {  
        public bool openL;

        public void OnPointerClick(PointerEventData data)
        {
            if(openL)
            {
                CloseDoorL();
            }
            else 
            {
                OpenDoorL();
            }
        }

        private void OpenDoorL()
        {
            gameObject.transform.Rotate(0, 50, 0);
            openL = true;
        }

        private void CloseDoorL()
        {
            gameObject.transform.Rotate(0, -50, 0);
            openL = false;
        }
    }
}
