using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveForce = 10.0f;
    Stack<State> _ListOfStates;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        _ListOfStates = new Stack<State>();
        _ListOfStates.Push(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        _ListOfStates.Peek().HandleInput(this);
        _ListOfStates.Peek().Update(this);
    }
    private void FixedUpdate()
    {
        _ListOfStates.Peek().FixedUpdate(this);
    }
    public void PushNewState(State newState)
    {
        _ListOfStates.Push(newState);
        _ListOfStates.Peek().Enter(this);
    }
    public void PopState()
    {
        _ListOfStates.Peek().Exit(this);
        _ListOfStates.Pop();
        _ListOfStates.Peek().Enter(this);
    }
}
