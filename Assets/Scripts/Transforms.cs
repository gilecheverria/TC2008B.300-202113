using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transforms
{
    public static Matrix4x4 MakeTranslate(float tx, float ty, float tz)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        mat[0, 3] = tx;
        mat[1, 3] = ty;
        mat[2, 3] = tz;
        return mat;
    }

    public static Matrix4x4 MakeScale(float sx, float sy, float sz)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        mat[0, 0] = sx;
        mat[1, 1] = sy;
        mat[2, 2] = sz;
        return mat;
    }

    public static Matrix4x4 MakeRotateX(float angle)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        float theta = angle * Mathf.Deg2Rad;
        float sin = Mathf.Sin(theta); 
        float cos = Mathf.Cos(theta); 
        mat[1, 1] = cos;
        mat[1, 2] = -sin;
        mat[2, 1] = sin;
        mat[2, 2] = cos;
        return mat;
    }

    public static Matrix4x4 MakeRotateY(float angle)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        float theta = angle * Mathf.Deg2Rad;
        float sin = Mathf.Sin(theta); 
        float cos = Mathf.Cos(theta); 
        mat[0, 0] = cos;
        mat[0, 2] = sin;
        mat[2, 0] = -sin;
        mat[2, 2] = cos;
        return mat;
    }

    public static Matrix4x4 MakeRotateZ(float angle)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        float theta = angle * Mathf.Deg2Rad;
        float sin = Mathf.Sin(theta); 
        float cos = Mathf.Cos(theta); 
        mat[0, 0] = cos;
        mat[0, 1] = -sin;
        mat[1, 0] = sin;
        mat[1, 1] = cos;
        return mat;
    }
}
