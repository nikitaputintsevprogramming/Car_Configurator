using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

namespace T34
{
    public class CanvasHistory : NetworkBehaviour, ITextureChangable
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler ChangeSpriteEvent;

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
            TextureChangeOn("Textures/Run/RunScreen");
            ChangeTransperentyRpc();
        }
        public void TextureChangeOn(string message)
        {
            Debug.Log("ÎÊ");
            Debug.Log($"Received notification: {message}");
            ChangeSpriteEvent?.Invoke(message);
            ChangeSpriteRpc(
                new MyStruct
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    SpriteId = message,
                    transpServerHistoryImage = 1
                }); // Client -> Server
        }

        [Rpc(SendTo.NotServer)]
        void ChangeSpriteRpc(MyStruct myStruct)
        {
            transform.position = myStruct.Position;

            Sprite receivedSprite = CreateSprite(myStruct.SpriteId);
            if (receivedSprite != null)
            {
                GetComponent<Image>().sprite = receivedSprite;
                Color col = GetComponent<Image>().color;
                col.a = myStruct.transpServerHistoryImage;
                GetComponent<Image>().color = col;
            }
        }

        [Rpc(SendTo.Server)]
        void ChangeTransperentyRpc()
        {
            Color newColor = GetComponent<Image>().color;
            newColor.a = 0;
            GetComponent<Image>().color = newColor;
        }

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
