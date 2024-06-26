using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new LabelData", menuName = "LabelData", order = 51)]
public class LabelData : ScriptableObject
{
    [SerializeField] private Vector3 cameraPos;
    [SerializeField] private Sprite labelIcon;

    public Vector3 CameraPos
    {
        get
        {
            return cameraPos;
        }
    }

    public Sprite LabelIcon
    {
        get
        {
            return labelIcon;
        }
    }
}
