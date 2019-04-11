using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControllerNew : MonoBehaviour {

    //Assign the object/pivot the planets are orbiting
    public Transform orbitPivot;

    //Set planets' orbit speed
    public float orbitSpeed;

    //Set planets' rotation speed
    public float rotationSpeed;

    void Start() {
        //Set anti-aliasing to use x8 Multisampling
        QualitySettings.antiAliasing = 8;
    }

    void Update() {
        //Updates Planet's position during each runtime frame
        this.transform.RotateAround(orbitPivot.position, Vector3.up, orbitSpeed * Time.deltaTime);
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    }
}
