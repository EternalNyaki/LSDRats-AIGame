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
        String,
        Color,
        Vector2
    }

    public static Type ConvertToType(PropertyType p)
    {
        switch (p)
        {
            case PropertyType.Integer:
                return typeof(int);

            case PropertyType.Float:
                return typeof(float);

            case PropertyType.Boolean:
                return typeof(bool);

            case PropertyType.String:
                return typeof(string);

            case PropertyType.Color:
                return typeof(Color);

            case PropertyType.Vector2:
                return typeof(Vector2);

            default:
                throw new Exception($"PropertyType {p} does not have an associated type");
        }
    }
}
