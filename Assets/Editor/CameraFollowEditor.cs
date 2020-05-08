using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//Added for editing

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor
{
    //Override GUI
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        //Reference the targer to follow
        CameraFollow cf = (CameraFollow)target;

        //Setting button when button is clicked
        if(GUILayout.Button("Set Min Cam Pos"))
        {
            cf.SetMinCamPosition();
        }


        //Setting button when button is clicked
        if (GUILayout.Button("Set Max Cam Pos"))
        {
            cf.SetMaxCamPosition();
        }
    }
}
