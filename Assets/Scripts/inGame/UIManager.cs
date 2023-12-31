using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_instantedStone; // Stone Manager 오브젝트의 하위에 있는 Instanted Stone 오브젝트 
    [SerializeField] GameObject m_UI; //inGame Scene의 Canvas(UI)

    public void _Restart()
    {

        for (int i = 0; i < m_instantedStone.transform.childCount; i++)
        {
            // 자식 오브젝트를 제거
            Destroy(m_instantedStone.transform.GetChild(i).gameObject);
        }

        Transform parentTransform = m_UI.transform;
        Transform lastChild = null;

        //UI의 마지막 child를 제거
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
