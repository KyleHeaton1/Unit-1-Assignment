using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    private bool faceLeft;
    public static void FlipPlayer(GameObject obj, bool faceLeft)
    {
        if (faceLeft == false)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (faceLeft == true)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
