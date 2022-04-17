using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    public bool itFlows = false;

    int PossibleRots = 1;

    GameManager gm;
    private Vector3 startingPosition;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;

        PossibleRots = correctRotation.Length;
        int randomStart = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[randomStart]);

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                itFlows = true;
                gm.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                itFlows = true;
                gm.correctMove();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90.0f));

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && itFlows == false)
            {
                itFlows = true;
                gm.correctMove();
            }
            else if (itFlows == true)
            {
                itFlows = false;
                gm.wrongMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0] && itFlows == false)
            {
                itFlows = true;
                gm.correctMove();
            }
            else if (itFlows == true)
            {
                itFlows = false;
                gm.wrongMove();
            }
        }
    }
}
