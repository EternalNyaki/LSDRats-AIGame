using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class CodeableObject : MonoBehaviour
{
    public Dictionary<string, object> properties;
    public List<Action<object>> actions;

    public GameObject terminalCodeSection;

    // Start is called before the first frame update
    void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        properties = new Dictionary<string, object>();
        actions = new List<Action<object>>();
    }

    void OnEnable()
    {
        StartCoroutine(LateEnable());
    }

    private IEnumerator LateEnable()
    {
        yield return new WaitForFixedUpdate();

        Debug.Log(gameObject.name + "Enabled");

        LoadProperties();
        LoadActions();

        UpdateProperties();
    }

    // Update is called once per frame
    void Update()
    {
        PlayActions();
    }

    protected void LoadProperties()
    {
        Dictionary<string, object> temp = new Dictionary<string, object>();

        foreach (UIPropertySlot codeSlot in terminalCodeSection.GetComponentsInChildren<UIPropertySlot>())
        {
            if (codeSlot.heldBlock == null)
            {
                temp.Add(codeSlot.gameObject.name, properties[codeSlot.gameObject.name]);
            }
            else
            {
                switch (codeSlot.GetAttachedCodeType())
                {
                    case CodeBlockType.NumberProperty:
                        temp.Add(codeSlot.gameObject.name, codeSlot.GetAttachedPropertyValue());
                        break;

                    case CodeBlockType.EnumProperty:
                        switch (CodeProperties.PropertyTypeFromType(codeSlot.GetAttachedPropertyValue().GetType()))
                        {
                            case CodeProperties.PropertyType.Boolean:
                                temp.Add(codeSlot.gameObject.name, CodeProperties.FromBoolValue((CodeProperties.BoolValue)codeSlot.GetAttachedPropertyValue()));
                                break;

                            case CodeProperties.PropertyType.Color:
                                temp.Add(codeSlot.gameObject.name, CodeProperties.FromColorValue((CodeProperties.ColorValue)codeSlot.GetAttachedPropertyValue()));
                                break;

                            case CodeProperties.PropertyType.Size:
                                temp.Add(codeSlot.gameObject.name, (CodeProperties.Size)codeSlot.GetAttachedPropertyValue());
                                break;

                            case CodeProperties.PropertyType.Shape:
                                temp.Add(codeSlot.gameObject.name, (CodeProperties.Shape)codeSlot.GetAttachedPropertyValue());
                                break;

                            case CodeProperties.PropertyType.Direction:
                                temp.Add(codeSlot.gameObject.name, CodeProperties.FromDirection((CodeProperties.Direction)codeSlot.GetAttachedPropertyValue()));
                                break;
                        }
                        break;
                }
            }
        }

        properties = temp;
    }

    protected void LoadActions()
    {
        actions.Clear();

        foreach (UIActionSlot codeSlot in terminalCodeSection.GetComponentsInChildren<UIActionSlot>())
        {
            if (codeSlot.heldBlock == null) { continue; }

            actions.Add(codeSlot.GetAttachedAction());
        }
    }

    protected virtual void UpdateProperties()
    {

    }

    protected virtual void PlayActions()
    {
        foreach (Action<object> a in actions)
        {
            a?.Invoke(this);
        }
    }
}
