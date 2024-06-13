using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class CanvasRunHistory : NetworkBehaviour
{
    [SerializeField] GameObject ImageRunHistory;

    [SerializeField] private Sprite RunAppSprite;
    [SerializeField] private Sprite HistoryModeSprite;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            CanvasClientOnRpc();
            CanvasHostOnRpc();
        }
    }

    private void Start()
    {
        CanvasClientOnRpc();
        CanvasHostOnRpc();
    }

    [Rpc(SendTo.NotServer)]
    void CanvasClientOnRpc()
    {
        Image image = GetComponent<Image>();
        image.sprite = RunAppSprite;
    }

    [Rpc(SendTo.Server)]
    void CanvasHostOnRpc()
    {
        gameObject.SetActive(false);
    }
}
