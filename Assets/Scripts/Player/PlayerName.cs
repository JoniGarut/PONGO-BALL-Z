using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [Header("References")]

    public TextMeshProUGUI uiTextName;
    public TextMeshProUGUI uiPlayerName;

    public TMP_InputField uiInputField;
    public GameObject changeNameInput;

    public Player player;

    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeName()
    {
        playerName = uiInputField.text;
        uiTextName.text = playerName;
        uiPlayerName.text = playerName;
        changeNameInput.SetActive(false);
        player.SetName(playerName);
    }
}
