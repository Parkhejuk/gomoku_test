using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject m_instantedStone; // Stone Manager ������Ʈ�� ������ �ִ� Instanted Stone ������Ʈ 

    public void _Reset()
    {
        
        for (int i = 0; i < m_instantedStone.transform.childCount; i++)
        {
            // �ڽ� ������Ʈ�� ����
            Destroy(m_instantedStone.transform.GetChild(i).gameObject);
        }
    }
}
