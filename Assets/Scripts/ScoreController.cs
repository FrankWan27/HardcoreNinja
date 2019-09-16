using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int p1Score;
    int p2Score;

    // Update is called once per frame
    public void UpdateScore()
    {
        string score = p1Score.ToString() + " : " + p2Score.ToString();
        GetComponent<Text>().text = score;
    }

    public void IncScore(Photon.Realtime.Player player)
    {
        Debug.Log(player + "Player was hit");
    }
}
