using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UI;

public class iconStuff : MonoBehaviour
{

    public Image fire;
    public Image poison;
    public Image stun;
    public Image healOverTime;
    public Image powerful;
    

    public int effectValue;

    private void Start()
    {
        fire.enabled = false;
        poison.enabled = false;
        stun.enabled = false;
        healOverTime.enabled = false;
        powerful.enabled = false;
    }


    public void Icon()
    {
        if(effectValue == 1)
        {
            fire.enabled = true;
        }
        if(effectValue == 2)
        {
            poison.enabled = true;
        }
        if(effectValue == 3)
        {
            stun.enabled = true;
        }
        if(effectValue == 4)
        {
            healOverTime.enabled = true;
        }
        if (effectValue == 5)
        {
            powerful.enabled = true;
        }
    }



}
