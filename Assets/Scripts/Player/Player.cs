using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public int maxPoints = 5;
    public Image uiPlayer;
    public string playerName;

    public Rigidbody2D myRigidbody2D;

    [Header("Key Steup")]
    public KeyCode keyCodeUp = KeyCode.W;
    public KeyCode keyCodeDown = KeyCode.S;

    [Header("Points")]
    public int currentPoints;

    public TextMeshProUGUI uiTMPpoints;


    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCodeUp))
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        //transform.Translate(transform.up * speed);

        else if (Input.GetKey(keyCodeDown))
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        //transform.Translate(transform.up * -speed);

    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    public void AddPoint()
    {
        currentPoints++;
        CheckMaxPoints();
        UpdateUI();
        Debug.Log(currentPoints);
    }

    public void UpdateUI()
    {
        uiTMPpoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if (currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.savePlayerWin(this);
        }
    }
}
