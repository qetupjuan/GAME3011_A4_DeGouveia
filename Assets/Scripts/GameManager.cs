using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] pipes;

    [SerializeField]
    public int totalPipes = 0;
    [SerializeField]
    int flowingPipes = 0;

    public bool win = false;
    public bool lose = false;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;
        pipes = new GameObject[totalPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        flowingPipes += 1;

        if (flowingPipes == totalPipes)
        {
            Debug.Log("You win!");
        }
    }

    public void wrongMove()
    {
        flowingPipes -= 1;
    }
}
