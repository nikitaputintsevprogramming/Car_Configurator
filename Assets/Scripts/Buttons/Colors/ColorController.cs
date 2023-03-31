using UnityEngine;

namespace Buttons.Colors
{
    public class ColorController : MonoBehaviour
    {   
        public GameObject target;        
    
        public void SetColor(string hexColorCode)
        {
            ColorUtility.TryParseHtmlString(hexColorCode, out var color);
        
            for (var countChildObjects = 0; countChildObjects < target.transform.childCount; countChildObjects++)
            {
                target.transform.GetChild(countChildObjects).GetComponent<MeshRenderer>().material.color = color;
                print(transform.childCount);
            }
        }   
    }
}
