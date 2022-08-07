using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI p1BombText;
    public TextMeshProUGUI p2BombText;

    public GameObject[] players;

    private void Update()
    {
        PlayersBombText();
    }
    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
            }

            if (aliveCount <= 1)
            {
                Invoke(nameof(NewRound), 3f);                
            }
        }
    }

    void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    void PlayersBombText()
    {
        p1BombText.text = "PLAYER 1 BOMBS :  " + players[0].GetComponent<BombController>().bombAmount.ToString();
        p2BombText.text = "PLAYER 2 BOMBS :  " + players[1].GetComponent<BombController>().bombAmount.ToString();
    }    
}
