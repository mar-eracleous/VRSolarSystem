using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {

    //Code from: https://blog.riccardogiorato.com/simple-teleport-script-unity-google-cardboard/

    public GameObject camera;
    private VReyecaster cameraEyeCast;

    //Communicate with VReyecaster script
    void Start() {
        cameraEyeCast = camera.GetComponent<VReyecaster>();
    }

    public void Recenter() {
#if !UNITY_EDITOR
    GvrCardboardHelpers.Recenter();
#else
        GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
        if (emulator == null) {
            return;
        }
        emulator.Recenter();
#endif
    }

    //Change position to the position of the raycast
    public void TeleportRandomly() {
        transform.position = cameraEyeCast.hitPoint();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
}