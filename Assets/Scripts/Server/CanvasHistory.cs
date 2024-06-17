using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

namespace T34
{
    public class CanvasHistory : NetworkBehaviour, TextureChangable
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler NotifyEvent;

        struct MyStruct : INetworkSerializable
        {
            public Vector3 Position;
            public Quaternion Rotation;
            public string SpriteId;

            // INetworkSerializable
            public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
            {
                serializer.SerializeValue(ref Position);
                serializer.SerializeValue(ref Rotation);
                serializer.SerializeValue(ref SpriteId);
            }
        }

        Sprite LoadSprite(string spriteId)
        {
            Texture2D texture = Resources.Load<Texture2D>(spriteId);
            if (texture != null)
            {
                return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            return null;
        }

        [Rpc(SendTo.NotServer)]
        void MyServerRpc(MyStruct myStruct)
        {
            transform.position = myStruct.Position;

            Sprite receivedSprite = LoadSprite(myStruct.SpriteId);
            if (receivedSprite != null)
            {
                GetComponent<Image>().sprite = receivedSprite;
            }
        }

        public override void OnNetworkSpawn()
        {
            NotifyEvent += OnNotifyReceived;
        }

        public void OnNotifyReceived(string message)
        {
            Debug.Log($"Received notification: {message}");
        }

        public void TextureChangeOn(string message)
        {
            Debug.Log("ÎÊ");
            Debug.Log($"Received notification: {message}");
            NotifyEvent?.Invoke(message);
            MyServerRpc(
                new MyStruct
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    SpriteId = "grass"
                }); // Client -> Server
        }
    }
}
