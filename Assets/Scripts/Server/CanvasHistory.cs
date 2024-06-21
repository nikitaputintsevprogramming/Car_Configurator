using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

namespace T34
{
    public class CanvasHistory : NetworkBehaviour, ITextureChangable
    {
        struct MyStruct : INetworkSerializable
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public string SpriteId;
            public float transpServerHistoryImage;

            // INetworkSerializable
            public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
            {
                serializer.SerializeValue(ref Position);
                serializer.SerializeValue(ref Rotation);
                serializer.SerializeValue(ref SpriteId);
                serializer.SerializeValue(ref transpServerHistoryImage);
            }
        }

        public override void OnNetworkSpawn()
        {
            //SetStructWithSpriteChangeClient("Textures/Run/RunScreen");
            ChangeTransperentyServerRpc(0f);
        }

        //--------------------- Texture ------------------
        // Client
        public void SetStructWithSpriteChangeClient(string message)
        {
            Debug.Log($"TextureChangeOn: {message}");
            ChangeSpriteClientRpc(
                new MyStruct
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    SpriteId = message,
                    transpServerHistoryImage = 1
                }); // Client -> Server
        }

        [Rpc(SendTo.NotServer)]
        void ChangeSpriteClientRpc(MyStruct myStruct)
        {
            transform.position = myStruct.Position;

            Sprite receivedSprite = CreateSprite(myStruct.SpriteId);
            if (receivedSprite != null)
            {
                GetComponent<Image>().sprite = receivedSprite;
                var imageComponent = GetComponent<Image>();
                if (imageComponent == null)
                {
                    Debug.LogWarning("Image component not found!");
                    return;
                }
                Color newColor = GetComponent<Image>().color;
                newColor.a = myStruct.transpServerHistoryImage;
                GetComponent<Image>().color = newColor;
            }
        }
        // Server
        public void SetStructWithSpriteChangeServer(string message)
        {
            Debug.Log($"TextureChangeOn: {message}");
            ChangeSpriteServerRpc(
                new MyStruct
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    SpriteId = message,
                    transpServerHistoryImage = 1
                }); // Client -> Server
        }

        [Rpc(SendTo.NotServer)]
        void ChangeSpriteServerRpc(MyStruct myStruct)
        {
            transform.position = myStruct.Position;

            Sprite receivedSprite = CreateSprite(myStruct.SpriteId);
            if (receivedSprite != null)
            {
                GetComponent<Image>().sprite = receivedSprite;
                var imageComponent = GetComponent<Image>();
                if (imageComponent == null)
                {
                    Debug.LogWarning("Image component not found!");
                    return;
                }
                Color newColor = GetComponent<Image>().color;
                newColor.a = myStruct.transpServerHistoryImage;
                GetComponent<Image>().color = newColor;
            }
        }
        //------------------------------------------------------
        //------------------------ Transperenty ----------------
        [Rpc(SendTo.Server)]
        public void ChangeTransperentyServerRpc(float trans)
        {
            var imageComponent = GetComponentInChildren<Image>();
            if (imageComponent == null)
            {
                Debug.LogWarning("Image component not found!");
                return;
            }
            Color newColor = imageComponent.color;
            newColor.a = trans;
            imageComponent.color = newColor;
        }

        [Rpc(SendTo.NotServer)]
        public void ChangeTransperentyClientRpc(float trans)
        {
            var imageComponent = GetComponentInChildren<Image>();
            if (imageComponent == null)
            {
                Debug.LogWarning("Image component not found!");
                return;
            }
            Color newColor = imageComponent.color;
            newColor.a = trans;
            imageComponent.color = newColor;
        }

        //void EnableDisableHistoryClient() => ChangeTransperentyRpc();

        Sprite CreateSprite(string spriteId)
        {
            Texture2D texture = Resources.Load<Texture2D>(spriteId);
            if (texture != null)
            {
                return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            return null;
        }
    }
}
