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

            // INetworkSerializable
            public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
            {
                serializer.SerializeValue(ref Position);
                serializer.SerializeValue(ref Rotation);
                serializer.SerializeValue(ref SpriteId);
            }
        }

        public override void OnNetworkSpawn()
        {
            print("Net spawn");
            TextureChangeOn("Textures/Run/RunScreen");
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

        //private void Start()
        //{
        //    ChangeSpriteEvent -= TextureChangeOn;
        //    Debug.Log("Отключаем событие");
        //}

        //public override void OnNetworkSpawn()
        //{
        //    ChangeSpriteEvent += TextureChangeOn;
        //    Debug.Log("Включаем событие");
        //}

        public void TextureChangeOn(string message)
        {
            Debug.Log("ОК");
            Debug.Log($"Received notification: {message}");
            ChangeSpriteEvent?.Invoke(message);
            MyServerRpc(
                new MyStruct
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    SpriteId = message
                }); // Client -> Server
        }
    }
}
