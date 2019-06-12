using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAroundScreen : MonoBehaviour
{
    public Transform loopTo;
    public float loopThreshold = -22f;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < loopThreshold)
        {
            gameObject.transform.position = loopTo.position;
        }
    }
}
