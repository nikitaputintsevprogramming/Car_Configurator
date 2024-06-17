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
            GUILayout.BeginArea(new Rect(10, 10, 1500, 1008));
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
            //if (GUILayout.Button("Server", GUILayout.Width(ButtonWidth), GUILayout.Height(ButtonHeight)))
            //    NetworkManager.Singleton.StartServer();
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