using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject m_instantedStone; // Stone Manager ������Ʈ�� ������ �ִ� Instanted Stone ������Ʈ 
    StoneManager m_stoneManager;
    public void _Restart()
    {

        for (int i = 0; i < m_instantedStone.transform.childCount; i++)
        {
            // �ڽ� ������Ʈ�� ����
            Destroy(m_instantedStone.transform.GetChild(i).gameObject);
        }
        m_stoneManager.m_IsOrder = true;
    }

    public void _MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
