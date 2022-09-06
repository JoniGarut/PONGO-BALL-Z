using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class PlayerColor : MonoBehaviour
{
    public Color color;

    [Header("References")]

    public Image uiImage;

    public Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        uiImage.color = color;
    }

    public void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}
