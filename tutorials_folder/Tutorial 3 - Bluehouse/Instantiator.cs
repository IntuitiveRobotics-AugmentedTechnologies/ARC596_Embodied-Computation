using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARCore;

public class Instantiator : MonoBehaviour
{
    public GameObject selectedPrefab;
    private GameObject instantiatedObject;
    public Transform arCameraTransform;

    private ARRaycastManager rayManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        InstantiateOnTouch();
        PinchToZoom(instantiatedObject);
    }

    private void HandleMode()
    {

        Debug.Log("***MODE 0***");
        Touch touch = Input.GetTouch(0);

        // Handle finger movements based on TouchPhase
        switch (touch.phase)
        {
            case TouchPhase.Began:
                InstantiateOnTouch();
                break; //break: If this case is true, it will not check the other ones. More computational efficiency, 

            case TouchPhase.Moved:

                if (Input.touchCount == 2)
                {
                    PinchToZoom(instantiatedObject);
                }
                break;

            case TouchPhase.Ended:
                Debug.Log("Touch Phase Ended.");
                break;
        }

    }

    void InstantiateOnTouch()
    {
        // Check if there is existing touch.
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (Input.touchCount == 1 && touch.phase != TouchPhase.Began)

        {
            Debug.Log("Single Touch");

            // Check if the raycast hit any trackables.
            if (rayManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first hit means the closest.
                var hitPose = hits[0].pose;

                // Check if there is already spawned object. If there is none, instantiated the prefab.
                if (instantiatedObject == null)
                {
                    instantiatedObject = Instantiate(selectedPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    // Change the spawned object position and rotation to the touch position.
                    instantiatedObject.transform.position = hitPose.position;
                    instantiatedObject.transform.rotation = hitPose.rotation;
                }

                // To make the spawned object always look at the camera. Delete if not needed.
                Vector3 lookPos = Camera.main.transform.position - instantiatedObject.transform.position;
                lookPos.y = 0;
                instantiatedObject.transform.rotation = Quaternion.LookRotation(lookPos);
            }
        }
    }


    void PinchToZoom(GameObject objectToZoom)
    {
        if (Input.touchCount == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            float pinchAmount = deltaMagnitudeDiff * -0.02f * Time.deltaTime;

            // Scale according to pinch amount
            objectToZoom.transform.localScale += new Vector3(pinchAmount, pinchAmount, pinchAmount);

            // Add rotation according to pinch position
            //objectToZoom.transform.Rotate(Vector3.up * 40f * Time.deltaTime * touchZero.deltaPosition.x, Space.Self);
        }
    }
}