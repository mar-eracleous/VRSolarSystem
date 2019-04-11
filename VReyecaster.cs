using System;
using UnityEngine;

public class VReyecaster : MonoBehaviour {

    //Code from: https://blog.riccardogiorato.com/simple-teleport-script-unity-google-cardboard/

    private Vector3 cordHit;

    [SerializeField] private Transform m_Camera;

    //Layers to exclude from the raycast.
    [SerializeField] private LayerMask m_ExclusionLayers;

    //Optionally show the debug ray.
    [SerializeField] private bool m_ShowDebugRay = true;

    //Debug ray length.
    private float m_DebugRayLength = 5f;

    //How long the Debug ray will remain visible.
    private float m_DebugRayDuration = 1f;

    //How far into the scene the ray is cast.
    private float m_RayLength = 500f;

    private void Update() {
        EyeRaycast();
    }

    public Vector3 hitPoint() {
        return cordHit;
    }


    private void EyeRaycast() {
        //Show the debug ray if required
        if (m_ShowDebugRay) {
            Debug.DrawRay(m_Camera.position, m_Camera.forward * m_DebugRayLength, Color.blue, m_DebugRayDuration);
        }

        //Create a ray that points forwards from the camera.
        Ray ray = new Ray(m_Camera.position, m_Camera.forward);
        RaycastHit hit;

        //Do the raycast forwards to see if we hit an interactive item
        if (Physics.Raycast(ray, out hit, m_RayLength, ~m_ExclusionLayers)) {
            cordHit = hit.point;
        }
    }
}