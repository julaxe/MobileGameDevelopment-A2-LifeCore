using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    public Sprite onPointerUpSprite;
    public Sprite onPointerDownSprite;

    private Image image;
    private CustomButton customButton;
    void Start()
    {
        customButton = GetComponent<CustomButton>();
        image = GetComponent<Image>();
        customButton.OnUp().AddListener(OnButtonUp);
        customButton.OnDown().AddListener(OnButtonDown);
    }

    private void OnButtonUp()
    {
        image.sprite = onPointerUpSprite;
    }

    private void OnButtonDown()
    {
        image.sprite = onPointerDownSprite;
    }
}
