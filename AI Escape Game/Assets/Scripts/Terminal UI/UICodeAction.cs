using System;
using UnityEngine;
using UnityEngine.Events;

[CodeBlockType(CodeBlockType.Action)]
public class UICodeAction : UICodeBlock
{
    public UnityEvent action;

    public Action value;

    protected override void Initialize()
    {
        value = action.Invoke;

        base.Initialize();
    }
}