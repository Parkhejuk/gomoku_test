using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject m_instantedStone; // Stone Manager 오브젝트의 하위에 있는 Instanted Stone 오브젝트 
    StoneManager m_stoneManager;
    public void _Restart()
    {

        for (int i = 0; i < m_instantedStone.transform.childCount; i++)
        {
            // 자식 오브젝트를 제거
            Destroy(m_instantedStone.transform.GetChild(i).gameObject);
        }
        m_stoneManager.m_IsOrder = true;
    }

    public void _MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
