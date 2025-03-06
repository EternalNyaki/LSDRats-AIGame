using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CodeProperties
{
    public enum PropertyType
    {
        Integer,
        Float,
        Boolean,
        Color
    }

    public enum NumberType
    {
        Integer = PropertyType.Integer,
        Float = PropertyType.Float
    }

    public enum EnumType
    {
        Boolean = PropertyType.Boolean,
        Color = PropertyType.Color
    }

    public enum BoolValue
    {
        False,
        True
    }

    public enum ColorValue
    {
        Red,
        Yellow,
        Green,
        Cyan,
        Blue,
        Magenta,
        White,
        Gray,
        Black
    }

    public static Type ConvertToType(PropertyType p)
    {
        switch (p)
        {
            case PropertyType.Integer: return typeof(int);
            case PropertyType.Float: return typeof(float);
            case PropertyType.Boolean: return typeof(BoolValue);
            case PropertyType.Color: return typeof(ColorValue);

            default: throw new Exception($"PropertyType {p} does not have an associated type");
        }
    }

    public static PropertyType PropertyTypeFromType(Type t)
    {
        if (t == typeof(int)) { return PropertyType.Integer; }
        if (t == typeof(float)) { return PropertyType.Float; }
        if (t == typeof(bool) || t == typeof(BoolValue)) { return PropertyType.Boolean; }
        if (t == typeof(Color) || t == typeof(ColorValue)) { return PropertyType.Color; }

        throw new ArgumentException($"Type {t} has no associated property type");
    }

    public static bool FromBoolValue(BoolValue value)
    {
        switch (value)
        {
            case BoolValue.False: return false;
            case BoolValue.True: return true;

            default: throw new Exception($"BoolValue {value} does not have a Boolean equivalent");
        }
    }

    public static Color FromColorValue(ColorValue value)
    {
        switch (value)
        {
            case ColorValue.Red: return Color.red;
            case ColorValue.Yellow: return Color.yellow;
            case ColorValue.Green: return Color.green;
            case ColorValue.Cyan: return Color.cyan;
            case ColorValue.Blue: return Color.blue;
            case ColorValue.Magenta: return Color.magenta;
            case ColorValue.White: return Color.white;
            case ColorValue.Gray: return Color.gray;
            case ColorValue.Black: return Color.black;

            default: throw new Exception($"ColorValue {value} does not have a Color equivalent");
        }
    }
}
