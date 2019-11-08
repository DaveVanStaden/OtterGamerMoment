using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSizeAssigner : MonoBehaviour
{
    private float ActualSize;
    void Start()
    {
        ActualSize = StaticVariable.ObjectSize;
        gameObject.transform.localScale = new Vector2(ActualSize, ActualSize);
    }
}
