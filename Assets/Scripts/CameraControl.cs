using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public int CameraSpeed;
    public bool StopMovement;

    public int CameraMoveArea;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            StopMovement = !StopMovement;

        var Pos = transform.position;
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - CameraMoveArea)
        {
            Pos.z += CameraSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= CameraMoveArea)
        {
            Pos.z -= CameraSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - CameraMoveArea)
        {
            Pos.x += CameraSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <=  CameraMoveArea)
        {
            Pos.x -= CameraSpeed * Time.deltaTime;
        }
        if(!StopMovement)
            transform.position = Pos;

        
    }
}
