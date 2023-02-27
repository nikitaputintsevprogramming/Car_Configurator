using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{    
    public Material CarMaterial;
    public Material[] ColorsResources;

    void Start()
    {
        // CarMaterial = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<MeshRenderer>().material;
        ColorsResources = Resources.LoadAll<Material>("Materials");
    }
    
    public void SetBlue()
    {
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<MeshRenderer>().material = ColorsResources[0];
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<MeshRenderer>().material = ColorsResources[0];
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<MeshRenderer>().material = ColorsResources[0];
    }

    public void SetRed()
    {
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<MeshRenderer>().material = ColorsResources[1];
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<MeshRenderer>().material = ColorsResources[1];
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<MeshRenderer>().material = ColorsResources[1];
    }

    public void SetYellow()
    {
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<MeshRenderer>().material = ColorsResources[2];
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<MeshRenderer>().material = ColorsResources[2];
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<MeshRenderer>().material = ColorsResources[2];
    }    
}
