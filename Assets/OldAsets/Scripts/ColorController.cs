using UnityEngine;

namespace Buttons.Colors
{
    public class ColorController : MonoBehaviour
    {   
        public GameObject target;    

        private MeshRenderer[] AllChildMeshRenderer;    
    
        public void SetColor(string hexColorCode)
        {
            ColorUtility.TryParseHtmlString(hexColorCode, out var color);
        
            AllChildMeshRenderer = target.GetComponentsInChildren<MeshRenderer>();

            for (int count = 0; count < AllChildMeshRenderer.Length; count++)
            {                
                AllChildMeshRenderer[count].material.color = color;                          
            }

            // for (var countChildObjects = 0; countChildObjects < target.transform.childCount; countChildObjects++)
            // {
            //     target.transform.GetComponentsInChildren<MeshRenderer>()[countChildObjects].material.color = color;
            //     print(transform.childCount);
            // }
        }   
    }
}
