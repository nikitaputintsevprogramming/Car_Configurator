using Unity.Netcode;
using UnityEngine;

namespace T34
{
    public class MultiplayerManager : MonoBehaviour
    {
        private const float ButtonWidth = 1000f;
        private const float ButtonHeight = 500f;

        void OnGUI()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            float centerX = (screenWidth - ButtonWidth) / 2;
            float centerY = (screenHeight - ButtonHeight * 2) / 2; // Умножаем ButtonHeight на 2, чтобы учесть две кнопки по высоте

            GUILayout.BeginArea(new Rect(centerX, centerY, ButtonWidth, ButtonHeight * 2)); // область для двух кнопок
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            {
                StartButtons();
            }
            else
            {
                StatusLabels();
                //SubmitNewPosition();
            }

            GUILayout.EndArea();
        }

        static void StartButtons()
        {
            if (GUILayout.Button("Host", GUILayout.Width(ButtonWidth), GUILayout.Height(ButtonHeight))) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Client", GUILayout.Width(ButtonWidth), GUILayout.Height(ButtonHeight))) NetworkManager.Singleton.StartClient();
            //if (GUILayout.Button("Server", GUILayout.Width(ButtonWidth), GUILayout.Height(ButtonHeight))) NetworkManager.Singleton.StartServer();
        }

        static void StatusLabels()
        {
            var mode = NetworkManager.Singleton.IsHost ?
                "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

            GUILayout.Label("Transport: " +
                NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
        }

        //static void SubmitNewPosition()
        //{
        //    if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Move" : "Request Position Change"))
        //    {
        //        if (NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsClient)
        //        {
        //            foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
        //                NetworkManager.Singleton.SpawnManager.GetPlayerNetworkObject(uid).GetComponent<Player>().Move();
        //            Debug.Log("Singleton.IsServer && !NetworkManager.Singleton.IsClient");
        //        }
        //        else
        //        {
        //            var playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
        //            var player = playerObject.GetComponent<Player>();
        //            player.Move();
        //            Debug.Log("Move");
        //        }
        //    }
        //}
    }
}
