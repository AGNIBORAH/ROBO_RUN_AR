using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTaptoPlace : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject robotPrefab;

    private GameObject activePrefab;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    // Start is called before the first frame update
    void Start()
    {
        activePrefab = null;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) //check if the screen has been tapped
        {
            if(activePrefab == null)
            {
                if(raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon )) //send invisible rays
                {
                    Pose hitpose = hits[0].pose;
                    activePrefab = Instantiate(robotPrefab, hitpose.position, Quaternion.identity); //instantiate the robot
                }
            }

        }
    }
}
