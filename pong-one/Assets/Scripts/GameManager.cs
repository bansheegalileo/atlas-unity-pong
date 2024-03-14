using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text playerOneScoreText;
    public TMP_Text playerTwoScoreText;
    public TMP_Text p1Message;
    public TMP_Text p2Message;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    private bool gameOver = false;

    private const int winningScore = 11;

    // upd8
    void Update()
    {
        if (!gameOver)
        {
            // upd8 ui
            playerOneScoreText.text = playerOneScore.ToString();
            playerTwoScoreText.text = playerTwoScore.ToString();

            // check 4 vict
            if (playerOneScore >= winningScore || playerTwoScore >= winningScore)
            {
                EndGame();
            }
        }
    }

    // scoring
    public void Score(bool playerOne)
    {
        if (!gameOver)
        {
            if (playerOne)
            {
                playerOneScore++;
            }
            else
            {
                playerTwoScore++;
            }
        }
    }

    // end game
    private void EndGame()
    {
        gameOver = true;

        // decide winner
        if (playerOneScore >= winningScore)
        {
            p1Message.gameObject.SetActive(true);
            p2Message.gameObject.SetActive(true);
            p1Message.text = "spiffy job!";
            p2Message.text = "end it all";
        }
        else
        {
            p1Message.gameObject.SetActive(true);
            p2Message.gameObject.SetActive(true);
            p1Message.text = "worthless";
            p2Message.text = "maybe you have a chance";
        }
    }
}
