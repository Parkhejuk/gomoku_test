using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GridVertexPrefab
public class MouseOnBoard : MonoBehaviour
{
    public GameObject m_onMousePrefab;

    GameObject m_generatedAStone;
    private void OnMouseEnter()
    {
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
