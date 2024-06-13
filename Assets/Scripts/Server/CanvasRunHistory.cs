using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

namespace T34
{
    public abstract class CanvasImageHandler : NetworkBehaviour
    {
        public abstract void SetImage(Sprite sprite);
    }

    public class CanvasRunHistory : CanvasImageHandler
    {
        [SerializeField] GameObject ImageRunHistory;

        [SerializeField] private Sprite RunAppSprite;

        private void OnEnable()
        {
            CanvasControl.OnBeginDragEvent += SetImage;
            Debug.Log("On Enable");
        }

        private void OnDisable()
        {
            CanvasControl.OnBeginDragEvent -= SetImage;
            Debug.Log("On Disable");
        }

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
            SetImage(RunAppSprite);
        }

        public override void SetImage(Sprite sprite)
        {
            Image image = ImageRunHistory.GetComponent<Image>();
            if (image != null)
            {
                image.sprite = sprite;
            }
        }

        [Rpc(SendTo.Server)]
        void CanvasHostOnRpc()
        {
            //gameObject.SetActive(false);
        }
    }
}


