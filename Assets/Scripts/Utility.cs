using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    private static Utility instance;
    public static Utility GetInstance() { return instance; }

    private void OnDestroy()
    {
        if (instance != null)
            Destroy(instance);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public float getWorldScaleOfX(Transform trans)
    {
        float x = trans.localScale.x;
        Transform parentTrans = trans;
        while (true)
        {
            if (parentTrans.parent != null)
            {
                x *= trans.parent.localScale.x;
                parentTrans = parentTrans.parent;
            }
            else
            {
                break;
            }
        }
        return x;
    }

    public float getWorldScaleOfY(Transform trans)
    {
        float y = trans.localScale.y;
        Transform parentTrans = trans;
        while (true)
        {
            if (parentTrans.parent != null)
            {
                y *= trans.parent.localScale.y;
                parentTrans = parentTrans.parent;
            }
            else
            {
                break;
            }
        }
        return y;
    }

    public float getWorldScaleOfZ(Transform trans)
    {
        float z = trans.localScale.z;
        Transform parentTrans = trans;
        while (true)
        {
            if (parentTrans.parent != null)
            {
                z *= trans.parent.localScale.z;
                parentTrans = parentTrans.parent;
            }
            else
            {
                break;
            }
        }
        return z;
    }
}
