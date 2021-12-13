using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public  class OnScreenInput : MonoBehaviour
{
    private CustomButton moveRightButton;
    private CustomButton moveLeftButton;
    private CustomButton pressJumpButton;
    private CustomButton pressShootButton;

    public float MoveX;
    public bool Jump;
    public bool Shoot;
    
    void Start()
    {
        moveRightButton = transform.Find("MovePlayer/MoveRight/Button").GetComponent<CustomButton>();
        moveLeftButton = transform.Find("MovePlayer/MoveLeft/Button").GetComponent<CustomButton>();
        pressJumpButton = transform.Find("Actions/Jump/Button").GetComponent<CustomButton>();
        pressShootButton = transform.Find("Actions/Shoot/Button").GetComponent<CustomButton>();
        
        moveRightButton.OnUp().AddListener(DontMove);
        moveRightButton.OnDown().AddListener(MoveRight);
        moveLeftButton.OnUp().AddListener(DontMove);
        moveLeftButton.OnDown().AddListener(MoveLeft);
        pressJumpButton.OnUp().AddListener(PressJumpUp);
        pressJumpButton.OnDown().AddListener(PressJumpDown);
        pressShootButton.OnUp().AddListener(PressShootUp);
        pressShootButton.OnDown().AddListener(PressShootDown);
    }

    private void DontMove()
    {
        MoveX = 0.0f;
    }

    private void MoveRight()
    {
        MoveX = 1.0f;
    }

    private void MoveLeft()
    {
        MoveX = -1.0f;
    }

    private void PressJumpDown()
    {
        Jump = true;
    }

    private void PressJumpUp()
    {
        Jump = false;
    }

    private void PressShootUp()
    {
        Shoot = false;
    }

    private void PressShootDown()
    {
        Shoot = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
