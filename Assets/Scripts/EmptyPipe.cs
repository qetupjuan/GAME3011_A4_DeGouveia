using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPipe : MonoBehaviour
{
    float[] rotations = { 0.0f, 90.0f, 180.0f, 270.0f };

    void Start()
    {
        int randomStart = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[randomStart]);
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90.0f));
    }
}
