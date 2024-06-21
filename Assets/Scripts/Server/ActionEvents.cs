using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace T34
{
    public class ActionEvents : MonoBehaviour
    {
        public event EventHandler OnActionPressed;

        public void ActionPressed()
        {
            OnActionPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
