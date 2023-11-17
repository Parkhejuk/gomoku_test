using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ �ٵ���(�迭�� ������) ����, ���� ���� ������Ʈ Ŭ����

public class CurrentBoardStateInit : MonoBehaviour
{
    [SerializeField] BoardManager m_boardManager;
    StoneBacksies m_stoneBacksies;

    // ���� ������, �� ĭ ���� ���� BoardManager���� ���� �޾� ��.
    int m_boardSize;
    float m_sideLeng;

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

    ///<summary> CurrentBoardStateInit.m_CurrentBoardState �迭�� player �����͸� �ִ� �Լ�</summary>
    public void UpdateBoardState(GameObject obj, RaycastHit hit, bool player)
    {
        GetMatrixNum(hit.point);
        m_CurrentBoardState[m_row, m_col] = player ? 1 : 0;

        //�������� ����
        m_stoneBacksies.SetBacksies(obj, m_row, m_col);

        //GetCurrenBoardStateArr();
    }

    //������ �ٵϵ� ������Ʈ(�ٵ��� ���� �� �ٵϵ�)�� ��ĵ����͸� ���ϴ� �Լ�
    void GetMatrixNum(Vector3 StoneWorldPoint)
    {
        m_row = Mathf.RoundToInt(StoneWorldPoint.x / m_sideLeng);
        m_col = Mathf.RoundToInt(StoneWorldPoint.y / m_sideLeng);
    }

    // �ٵ����� ���� ���¸� Consoleâ�� ���� Debug �Լ�
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

    void Start()
    {
        m_stoneBacksies = FindObjectOfType<StoneBacksies>();

        m_boardSize = m_boardManager.m_BoardSize;
        m_sideLeng = m_boardManager.m_SideLeng;

        BoardStateArrInit();

    }
}