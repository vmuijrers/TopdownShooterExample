﻿using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateMachine Controller;
    public void Initalize(StateMachine owner)
    {
        Controller = owner;
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
}
