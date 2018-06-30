using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForbiddenZoneControler : MonoBehaviour {

    public NavMeshSurface navmesh;
    public CameraControl cam;

    bool follow = false;

    void OnMouseDown()
    {
        follow = true;
        cam.DeactivatePan = true;
    }

    void OnMouseUp()
    {
        follow = false;
        navmesh.BuildNavMesh();
        cam.DeactivatePan = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(follow)
        {
            Vector3 pos;
            if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer)
            {
                pos=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else
            {
                pos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }
}
