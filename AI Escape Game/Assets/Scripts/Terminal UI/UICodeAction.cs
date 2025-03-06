using System;
using UnityEngine;
using UnityEngine.Events;

[CodeBlockType(CodeBlockType.Action)]
public class UICodeAction : UICodeBlock
{
    public UnityEvent<object> action;

    public Action<object> value;

    protected override void Initialize()
    {
        value = action.Invoke;

        base.Initialize();
    }
}