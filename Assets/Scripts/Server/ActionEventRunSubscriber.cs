using System.Collections;
using UnityEngine;
using System;

namespace T34
{
    public class ActionEventRunSubscriber: MonoBehaviour
    {
        private void Start()
        {
            ActionEvents testingEvents = FindObjectOfType<ActionEvents>();
            testingEvents.OnActionPressed += ActionEvents_ActionPressed;
        }

        private void ActionEvents_ActionPressed(object sender, EventArgs e)
        {
            Debug.Log("Action!");
            CanvasHistory canvasControl = FindObjectOfType<CanvasHistory>();
            canvasControl.ChangeTransperentyServerRpc(1);
            canvasControl.SetStructWithSpriteChangeClient("Textures/ActionMode/aim");

            Transform camTransform = Camera.main.transform;
            camTransform.position = new Vector3(0, 3.5f, -5.5f);
            camTransform.rotation = Quaternion.identity;
        }
    }
}