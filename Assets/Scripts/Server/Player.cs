using Unity.Netcode;
using UnityEngine;

namespace T34
{
    public class Player : NetworkBehaviour
    {
        //public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                //Move();
                transform.rotation = Quaternion.Euler(-90, 0, 0);
            }
        }



        //public void Move()
        //{
        //    SubmitPositionRequestServerRpc();
        //}

        //[Rpc(SendTo.Server)]
        //void SubmitPositionRequestServerRpc(RpcParams rpcParams = default)
        //{
        //    var randomPosition = GetRandomPositionOnPlane();
        //    transform.position = randomPosition;
        //    Position.Value = randomPosition;
        //    Debug.Log("new position");
        //}

        //static Vector3 GetRandomPositionOnPlane()
        //{
        //    return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        //}

        //void Update()
        //{
        //    transform.position = Position.Value;
        //}
    }
}