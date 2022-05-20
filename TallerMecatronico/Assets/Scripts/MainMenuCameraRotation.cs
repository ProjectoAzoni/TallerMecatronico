using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraRotation : MonoBehaviour
{
    //Reference for the main camera
    private Camera camera01;

    //position of the camera , position of the place the camera will rotate
    private Transform cameraTransform, cameraDesiredLookAt;

    private void Start()
    {
        //find and set the main camera
        camera01 = Camera.main;
        //find the position and rotation of the main camera
        cameraTransform = camera01.transform;
    }

    private void Update()
    {
        RotateCamera();
    }
    //Rotate the main camera to the desired point
    void RotateCamera() {
        //if there is something to look at
        if (cameraDesiredLookAt != null) {
            //rotate the camera
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, 4 * Time.deltaTime);
        }
    }
    //Asign the point to rotate the camera
    public void LookAtMenu(Transform menuPos) {
        cameraDesiredLookAt = menuPos;
    }
}
