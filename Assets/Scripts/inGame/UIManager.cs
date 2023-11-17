using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_instantedStone; // Stone Manager ������Ʈ�� ������ �ִ� Instanted Stone ������Ʈ 
    [SerializeField] GameObject m_UI; //inGame Scene�� Canvas(UI)

    public void _Restart()
    {

        for (int i = 0; i < m_instantedStone.transform.childCount; i++)
        {
            // �ڽ� ������Ʈ�� ����
            Destroy(m_instantedStone.transform.GetChild(i).gameObject);
        }

        Transform parentTransform = m_UI.transform;
        Transform lastChild = null;

        //UI�� ������ child�� ����
        foreach (Transform child in parentTransform)
        {
            lastChild = child;
        }
        if (lastChild != null && lastChild.gameObject.tag == "Result")
        {
            Destroy(lastChild.gameObject);
        }

    }

    public void _MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
