using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� Ŭ����
public class StoneBacksies : MonoBehaviour
{
    CurrentBoardStateInit m_currentBoardStateInit;

    //������ GameObject �����͸� ������ ����
    GameObject m_obj1;
    GameObject m_obj2;

    //������ ��İ��� ������ ����;
    public int[] m_stoneBacksies1 { get; set; }
    public int[] m_stoneBacksies2 { get; set; }

    //�������� �����ϴ� �Լ� (�ִ� 1ȸ����);
    public void SetBacksies1(int row, int col, GameObject obj)
    {
        if (m_stoneBacksies1[0] == 0)
        {
            m_stoneBacksies1[0] = row;
            m_stoneBacksies1[1] = col;
        }
        else
        {
            SetBacksies2();
            m_stoneBacksies1[0] = row;
            m_stoneBacksies1[1] = col;
        }
        m_obj1 = obj;
    }
    void SetBacksies2()
    {
        m_stoneBacksies2[0] = m_stoneBacksies1[0];
        m_stoneBacksies2[1] = m_stoneBacksies1[1];
        m_obj2 = m_obj1;
    }

    //Backsies ��ư�� ������ ����Ǵ� �Լ�
    public void BacksiesButtonDown()
    {
        if (m_obj1 != null && m_obj2 != null) //���� ������ �ϳ� ���� �� ���� �Ұ���. ���� �� ���� �� �̺κ� �ٽ� Ȯ��
        {
            m_currentBoardStateInit.m_CurrentBoardState[m_stoneBacksies1[0], m_stoneBacksies1[1]] = -1;
            m_currentBoardStateInit.m_CurrentBoardState[m_stoneBacksies2[0], m_stoneBacksies2[1]] = -1;

            Destroy(m_obj1);
            Destroy(m_obj2);

            Debug.Log("���� ���Ƚ��ϴ�.");
        }
        else
        {
            Debug.Log("���� ���� �� �����ϴ�.");
        }
    }

    //�ϴ� ������ Debug�Լ� �����ϰ� �����ؼ� ����
    void GetBacksiesData()
    {
        Debug.Log("1: " + m_stoneBacksies1[0] + ", " + m_stoneBacksies1[1]);
        Debug.Log("2: " + m_stoneBacksies2[0] + ", " + m_stoneBacksies2[1]);
        Debug.Log("1: " + m_obj1.transform.position);
        Debug.Log("2" + m_obj2.transform.position);
    }

    void Start()
    {
        m_currentBoardStateInit = FindAnyObjectByType<CurrentBoardStateInit>();

        m_stoneBacksies1 = new int[2];
        m_stoneBacksies2 = new int[2];
    }
}
