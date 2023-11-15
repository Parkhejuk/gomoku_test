using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCastUtil : MonoBehaviour
{
    public static bool RaycastFromMouse(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //UI ������ ���콺 �̺�Ʈ ����
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            //hit = new RaycastHit();
            return false;
        }
        return Physics.Raycast(ray, out hit, Mathf.Infinity);
    }
}
