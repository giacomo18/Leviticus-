using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class JTest : MonoBehaviour
{
    [SerializeField] Canvas CanvasOne;
    [SerializeField] Canvas CanvasTwo;
    [SerializeField] Canvas CanvasThree;

    public void Start()
    {
        CanvasOne.enabled = false;
        CanvasTwo.enabled = false;
        CanvasThree.enabled = false;
    }



    public void ButtonEffect(int Interact)
    {
        if(Interact == 1)
        {
            CanvasOne.enabled = true;
            CanvasTwo.enabled = false;
            CanvasThree.enabled = false;

        }
        if(Interact == 2)
        {
            CanvasOne.enabled = false;
            CanvasTwo.enabled = true;
            CanvasThree.enabled = false;

        }
        if(Interact == 3)
        {
            CanvasOne.enabled = false;
            CanvasTwo.enabled = false;
            CanvasThree.enabled = true; ;
        }
    }
}
