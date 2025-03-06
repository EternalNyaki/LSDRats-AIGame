using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodableObject : MonoBehaviour
{
    public GameObject code;

    protected Dictionary<string, object> _propertiesList;
    protected List<Action> _actionsList;

    void Start()
    {
        _propertiesList = new Dictionary<string, object>();
        _actionsList = new List<Action>();

        Initialize();
    }

    protected virtual void Initialize()
    {

    }

    void OnEnable()
    {
        ReloadProperties();
        LoadActions();
    }

    // Update is called once per frame
    void Update()
    {
        RunCode();
    }

    // public void GetEditableCodeFromTerminal(out List<CustomizableProperty> properties, out List<UnityEvent> actions)
    // {
    //     properties = new List<CustomizableProperty>();
    //     actions = new List<UnityEvent>();

    //     UIDropZone[] dropZones = code.GetComponentsInChildren<UIDropZone>();

    //     foreach (UIDropZone dropZone in dropZones)
    //     {
    //         if (dropZone.heldBlock != null)
    //         {
    //             UICodeBlock block = (UICodeBlock)dropZone.heldBlock;
    //             if (block != null)
    //             {
    //                 try
    //                 {
    //                     UICodeAction action = (UICodeAction)block;
    //                     actions.Add(action.action);
    //                     continue;
    //                 }
    //                 catch (InvalidCastException e)
    //                 {

    //                 }

    //                 try
    //                 {
    //                     UICodeProperty property = (UICodeProperty)block;
    //                     if (property != null)
    //                     {
    //                         properties.Add(property.defaultValue);
    //                         continue;
    //                     }
    //                 }
    //                 catch (InvalidCastException e)
    //                 {

    //                 }
    //             }
    //         }
    //     }
    // }

    protected void RunCode()
    {
        foreach (Action a in _actionsList)
        {
            a.Invoke();
        }
    }

    protected virtual void ReloadProperties()
    {

    }

    protected virtual void LoadActions()
    {

    }
}
