using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotations;
    public bool itFlows;
    int possibleRotations = 1;

    GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        possibleRotations = correctRotations.Length;
        int randomRotation = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[randomRotation]);

        if (possibleRotations > 1)
        {
            if (transform.eulerAngles.z == correctRotations[0] ||
                transform.eulerAngles.z == correctRotations[1])
            {
                if (itFlows == false)
                {
                    itFlows = true;
                    gm.correctMove();
                }
            }
            else
            {
                if (itFlows == true)
                {
                    itFlows = false;
                    gm.wrongMove();
                }
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotations[0])
            {
                if (itFlows == false)
                {
                    itFlows = true;
                    gm.correctMove();
                }
            }
            else
            {
                if (itFlows == true)
                {
                    itFlows = false;
                    gm.wrongMove();
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (gm.won == false && gm.lost == false)
        {
            transform.Rotate(new Vector3(0, 0, 90));

            if (possibleRotations > 1)
            {
                if (transform.eulerAngles.z == correctRotations[0] ||
                    transform.eulerAngles.z == correctRotations[1])
                {
                    if (itFlows == false)
                    {
                        itFlows = true;
                        gm.correctMove();
                    }
                }
                else
                {
                    if (itFlows == true)
                    {
                        itFlows = false;
                        gm.wrongMove();
                    }
                }
            }
            else
            {
                if (transform.eulerAngles.z == correctRotations[0])
                {
                    if (itFlows == false)
                    {
                        itFlows = true;
                        gm.correctMove();
                    }
                }
                else
                {
                    if (itFlows == true)
                    {
                        itFlows = false;
                        gm.wrongMove();
                    }
                }
            }
        }
    }
}