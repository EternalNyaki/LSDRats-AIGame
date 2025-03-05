using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UICodeProperty : UICodeBlock
{
    [NonSerialized] public CodeProperties.PropertyType propertyType;

    public CustomizableProperty defaultValue = new CustomizableProperty<int>();

    protected override void Initialize()
    {
        base.Initialize();
    }
}

public abstract class CustomizableProperty
{

}

public class CustomizableProperty<T> : CustomizableProperty
{
    protected T _value;

    public CustomizableProperty()
    {
        _value = default;
    }

    public CustomizableProperty(T value)
    {
        _value = value;
    }

    public static implicit operator T(CustomizableProperty<T> p)
    {
        return p._value;
    }
    public static implicit operator CustomizableProperty<T>(T t)
    {
        return new CustomizableProperty<T>(t);
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(UICodeProperty))]
public class UICodePropertyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var editorObject = (UICodeProperty)target;

        var temp = editorObject.propertyType;
        editorObject.propertyType = (CodeProperties.PropertyType)EditorGUILayout.EnumPopup("Property Type", editorObject.propertyType);
        if (editorObject.propertyType != temp)
        {
            switch (editorObject.propertyType)
            {
                case CodeProperties.PropertyType.Integer:
                    editorObject.defaultValue = new CustomizableProperty<int>();
                    break;

                case CodeProperties.PropertyType.Float:
                    editorObject.defaultValue = new CustomizableProperty<float>();
                    break;

                case CodeProperties.PropertyType.Boolean:
                    editorObject.defaultValue = new CustomizableProperty<bool>();
                    break;

                case CodeProperties.PropertyType.String:
                    editorObject.defaultValue = new CustomizableProperty<string>();
                    break;

                case CodeProperties.PropertyType.Color:
                    editorObject.defaultValue = new CustomizableProperty<Color>();
                    break;

                case CodeProperties.PropertyType.Vector2:
                    editorObject.defaultValue = new CustomizableProperty<Vector2>();
                    break;
            }
        }

        switch (editorObject.propertyType)
        {
            case CodeProperties.PropertyType.Integer:
                var intProperty = (CustomizableProperty<int>)editorObject.defaultValue;
                intProperty = EditorGUILayout.IntField("Default Value", intProperty);
                editorObject.defaultValue = intProperty;
                break;

            case CodeProperties.PropertyType.Float:
                var floatProperty = (CustomizableProperty<float>)editorObject.defaultValue;
                floatProperty = EditorGUILayout.FloatField("Default Value", floatProperty);
                editorObject.defaultValue = floatProperty;
                break;

            case CodeProperties.PropertyType.Boolean:
                var boolProperty = (CustomizableProperty<bool>)editorObject.defaultValue;
                boolProperty = EditorGUILayout.Toggle("Default Value", boolProperty);
                editorObject.defaultValue = boolProperty;
                break;

            case CodeProperties.PropertyType.String:
                var stringProperty = (CustomizableProperty<string>)editorObject.defaultValue;
                stringProperty = EditorGUILayout.TextField("Default Value", stringProperty);
                editorObject.defaultValue = stringProperty;
                break;

            case CodeProperties.PropertyType.Color:
                var colorProperty = (CustomizableProperty<Color>)editorObject.defaultValue;
                colorProperty = EditorGUILayout.ColorField("Default Value", colorProperty);
                editorObject.defaultValue = colorProperty;
                break;

            case CodeProperties.PropertyType.Vector2:
                var vectorProperty = (CustomizableProperty<Vector2>)editorObject.defaultValue;
                vectorProperty = EditorGUILayout.Vector2Field("Default Value", vectorProperty);
                editorObject.defaultValue = vectorProperty;
                break;
        }
    }
}
#endif