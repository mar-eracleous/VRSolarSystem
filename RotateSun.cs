using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour {

    public Transform orbitPivot;
    public float orbitSpeed;
    public float rotationSpeed;

    void Start () {

        Vector2 randomPosition = Random.insideUnitCircle;
        transform.position = new Vector3(transform.position.x, 0f, randomPosition.y);

    }
	
	void Update () {
        this.transform.RotateAround(orbitPivot.position, Vector3.up, orbitSpeed * Time.deltaTime);
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
