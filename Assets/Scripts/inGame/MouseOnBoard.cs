using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// GridVertexPrefab
public class MouseOnBoard : MonoBehaviour
{
    [SerializeField] GameObject m_onMousePrefab;

    GameObject m_generatedAStone;
    private void OnMouseEnter()
    {
        //UI ������ ���콺 �̺�Ʈ ����
        if (!EventSystem.current.IsPointerOverGameObject())
            m_generatedAStone = Instantiate(m_onMousePrefab, transform.position, Quaternion.identity);
    }

    private void OnMouseExit()
    {
        if (m_generatedAStone != null)
        {
            Destroy(m_generatedAStone);
        }
    }
}
