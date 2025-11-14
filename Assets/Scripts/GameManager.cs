using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Pacman pacman;
    public Ghost[] ghosts;
    public Transform pellets;

    public int Lives { get; private set; }
    public int Score { get; private set; }

    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetLives(3);
        SetScore(0);
        NewRound();
    }

    private void SetLives(int lives)
    {
        Lives = lives;
    }

    private void SetScore(int score)
    {
        Score = score;
    }

    private void NewRound()
    {
        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.gameObject.SetActive(true);
        }

        pacman.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(Score + ghost.points);
    }

    public void PacmanEaten()
    {
        pacman.gameObject.SetActive(false);

        SetLives(Lives - 1);

        if(Lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }

    }
}
