using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class ImageClient : NetworkBehaviour
{
    [SerializeField] private Sprite RunAppSprite;
    [SerializeField] private Sprite HistoryModeSprite;


    // Start is called before the first frame update
    //public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            CanvasOnRpc();
        }
    }

        // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.H))
    //    {
    //        CanvasOnRpc();
    //    }
        
    //}

    [Rpc(SendTo.NotServer)]
    void CanvasOnRpc()
    {
        Image image = GetComponent<Image>();
        image.sprite = RunAppSprite;
    }
}
