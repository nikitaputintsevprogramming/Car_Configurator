using UnityEngine;
using UnityEditor;

public class ColorController : MonoBehaviour
{   
    public GameObject target;

    public Material[] ColorsResources;

    public int TargetBodyChildObjects = 3;


    private void Start()
    {
        // CarMaterial = target.transform.GetChild(0).GetComponent<MeshRenderer>().material;
        ColorsResources = Resources.LoadAll<Material>("Materials");
    }
    
    public void SetColor(string HexColorCode)
    {
        Color color;
        ColorUtility.TryParseHtmlString(HexColorCode, out color);

        for (int countChildObjects = 0; countChildObjects < TargetBodyChildObjects; countChildObjects++)
        {
            target.transform.GetChild(countChildObjects).GetComponent<MeshRenderer>().material.color = color;
        }
    }   
}
