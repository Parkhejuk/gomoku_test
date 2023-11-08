using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastUtil : MonoBehaviour
{

    public static bool RaycastFromMouse(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit, Mathf.Infinity);
    }

}
