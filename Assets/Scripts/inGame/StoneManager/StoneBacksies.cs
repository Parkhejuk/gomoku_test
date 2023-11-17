using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� Ŭ����
public class StoneBacksies : MonoBehaviour
{
    CurrentBoardStateInit m_currentBoardStateInit;

    // Util������ �ִ� Dequeue Script, ����� ���� Ŭ����
    // LinkedList<T>�� �����Ǿ� �־ ����� ���ѵ� LinkedList�� �����ϸ� ��
    Dequeue<int> m_row = new Dequeue<int>();
    Dequeue<int> m_col = new Dequeue<int>();
    Dequeue<GameObject> m_Stoneobj = new Dequeue<GameObject>();

    //�������� �����ϴ� �Լ�;
    public void SetBacksies(GameObject obj, int row, int col)
    {
        m_row.PushBack(row);
        m_col.PushBack(col);
        m_Stoneobj.PushBack(obj);
    }

    //Backsies ��ư�� ������ ����Ǵ� �Լ�
    public void BacksiesButtonDown()
    {
        //������ �ٵϵ��� ���ų� �浹 �� ���� ���� �� Backsies ����
        if (m_Stoneobj.Count != 0 && m_Stoneobj.Count != 1)
        {
            int row = m_row.PopBack();
            int col = m_col.PopBack();

            m_currentBoardStateInit.m_CurrentBoardState[row, col] = -1;

            Destroy(m_Stoneobj.PopBack());

            Debug.Log("���� ���Ƚ��ϴ�.");
        }
        else
        {
            Debug.Log("���� ���� �� �����ϴ�.");
        }
    }

    //Restart ��ư�� ������ ����Ǵ� �Լ�
    public void RestartButtonDown()
    {
        // Dequeue�� ����Ǿ� �ִ� �����͵� ���� ����
        m_row.Clear();
        m_col.Clear();
        m_Stoneobj.Clear();
    }

    void Start()
    {
        m_currentBoardStateInit = FindAnyObjectByType<CurrentBoardStateInit>();
    }
}
