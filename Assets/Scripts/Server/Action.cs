using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Action : MonoBehaviour
{
    public delegate void AccountHandler(string message);
    public event AccountHandler? Notify;

    public void ActionEnable()
    {
        ChangeTransperentyServerRpc(1);
        ChangeTransperentyClientRpc(0);

        Transform camTransform = Camera.main.transform;
        camTransform.position = new Vector3(0, 3.5f, -5.5f);
        camTransform.rotation = Quaternion.identity;
    }
}
