using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy objInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (objInstance == null)
        {
            objInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
