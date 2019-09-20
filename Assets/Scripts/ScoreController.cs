using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public int p1ID = -1;
    public int p2ID = -1;

    public void UpdateScore()
    {
        string score = p1Score.ToString() + " : " + p2Score.ToString();
        GetComponent<Text>().text = score;
    }

    public void IncScore(int player)
    {
        if (p1ID == -1)
            p1ID = player;
        if (p1ID != player && p2ID == -1)
            p2ID = player;


        if (p1ID == player)
            p1Score++;
        if (p2ID == player)
            p2Score++;

        Debug.Log(player + "Player was hit");

        UpdateScore();
    }
}
