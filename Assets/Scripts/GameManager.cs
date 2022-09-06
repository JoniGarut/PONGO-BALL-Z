using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;

    public static GameManager Instance;

    public float timeToSetBallFree = 1f;

    public StateMachine stateMachine;
        
    public Player[] players;

    [Header("Menus")]
    public GameObject uiMainMenu;

    private bool _setBallFree = true;

    private void Awake()
    {
        Instance = this;

        players = FindObjectsOfType<Player>();
    }

    public void SwitchStateReset() /*ResetBallPosition*/
    {
        stateMachine.ResetPosition();
    }

    public void ResetBall(bool setBallFreeable = true)
    {
        _setBallFree = setBallFreeable;
        ballBase.CanMove(false);
        ballBase.ResetBall();
        if (_setBallFree)
        {
            Invoke(nameof(SetBallFree), timeToSetBallFree);
        }
    }

    public void ResetPlayers()
    {
        foreach (var player in players)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        if (_setBallFree)
        {
            ballBase.CanMove(true);
        }
    }

    public void StartGame()
    {
        _setBallFree = true;
        ballBase.CanMove(true);
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        
        // não funciona!
        ballBase.CanMove(false);
        ResetBall(false);
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
    }
}
