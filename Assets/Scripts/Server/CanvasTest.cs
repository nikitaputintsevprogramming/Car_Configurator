using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class CanvasTest : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            CanvasOnRpc();
        }
        
    }

    [Rpc(SendTo.NotServer)]
    void CanvasOnRpc()
    {
        transform.gameObject.SetActive(false);
    }
}
