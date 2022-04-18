using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] pipes;

    [SerializeField]
    public float timer = 90;
    [SerializeField]
    public int totalPipes = 0;
    [SerializeField]
    int flowingPipes = 0;

    public GameObject win;
    public GameObject lose;
    public bool won = false;
    public bool lost = false;

    [SerializeField]
    private TMPro.TextMeshProUGUI timeText;

    void Start()
    {
        timeText.text = "Time: " + timer.ToString();

        totalPipes = PipesHolder.transform.childCount;
        pipes = new GameObject[totalPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }
    void Update()
    {
        if (timer < 0)
        {
            Lost();
        }
        else
        {
            timer -= Time.deltaTime;
            timeText.text = "Time: " + (int)timer;
        }
    }
    public void correctMove()
    {
        flowingPipes += 1;

        if (flowingPipes == totalPipes)
        {
            Won();
        }
    }

    public void wrongMove()
    {
        flowingPipes -= 1;
    }
    public void Won()
    {
        Debug.Log("You win!");
        won = true;
        win.SetActive(true);
    }
    public void Lost()
    {
        Debug.Log("You lost!");
        lost = true;
        lose.SetActive(true);
    }
}
