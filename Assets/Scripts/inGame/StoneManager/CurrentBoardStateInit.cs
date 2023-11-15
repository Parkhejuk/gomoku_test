using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �ٵ���(�迭�� ������) ����, ���� ���� ������Ʈ Ŭ����

public class CurrentBoardStateInit : MonoBehaviour
{
    StoneManager m_stoneManager;
    StoneBacksies m_stoneBacksies;

    const int m_boardSize = 15;
    const float m_sideLeng = 0.3925f;

    //������ ������¸� �����ϴ� �迭���� & �������鿡 �ο��� �࿭ ��ȣ�� ������ ����
    public int[,] m_CurrentBoardState { get; set; }

    int m_row, m_col;

    public int m_Row { get { return m_row; } }
    public int m_Col { get { return m_col; } }


    // �ٵ����� ������¸� ������ �ٵ��� �迭�� �����ϴ� �Լ� 
    // -1: �������, 0: �鵹, 1: �浹
    public void BoardStateArrInit()
    {
        m_CurrentBoardState = new int[m_boardSize, m_boardSize];
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                m_CurrentBoardState[i, j] = -1;
            }
        }
    }

    // �ٵ����� ���� ���¸� Log�� ���� �Լ�
    void GetCurrenBoardStateArr()
    {
        string s = null;
        for (int i = 0; i < m_boardSize; i++)
        {
            for (int j = 0; j < m_boardSize; j++)
            {
                s += m_CurrentBoardState[j, 14 - i] + " ";
            }
            s += "\n";
        }
        Debug.Log(s);
    }

    //������ �ٵϵ� ������Ʈ(�ٵ��� ���� �� �ٵϵ�)�� ��İ��� ���ϴ� �Լ�
    void GetMatrixNum(Vector3 StoneWorldPoint)
    {
        m_row = Mathf.RoundToInt(StoneWorldPoint.x / m_sideLeng);
        m_col = Mathf.RoundToInt(StoneWorldPoint.y / m_sideLeng);
    }
    // m_CurrentBoardState �迭�� 1, 0 �� �ִ� �Լ�
    public void UpdateBoardState(GameObject obj)
    {
        GetMatrixNum(m_stoneManager.hit.point);
        m_CurrentBoardState[m_row, m_col] = m_stoneManager.m_IsOrder ? 1 : 0;

        //�������� ����
        m_stoneBacksies.SetBacksies(m_row, m_col, obj);

        GetCurrenBoardStateArr();
    }

    void Start()
    {
        m_stoneManager = FindObjectOfType<StoneManager>();
        m_stoneBacksies = FindObjectOfType<StoneBacksies>();

        BoardStateArrInit();

    }
}