using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Gira el objeto en el eje Z a una velocidad espec�fica
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

