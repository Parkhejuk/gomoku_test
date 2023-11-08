using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ӷ� ���� Ŭ����

public class RuleManager : MonoBehaviour
{
    CurrentBoardStateInit m_currentBoardStateInit;

    public void CheckRule(int player, int row, int col)
    {
        if (CheckWin(player, row, col))
        {
            if (player == 1)
                Debug.Log("��������\n �� �¸�!");
            else
                Debug.Log("��������\n �� �¸�!");
        }
    }
    public bool CheckBlack43(int player, int row, int col)
    {
        // ���� ������ ũ�� (���� �� ����)
        int boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        // ����, ����, �밢�� ������ Ȯ��
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            int count = 1; // ���� ��ġ�������� count ����

            for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
            {
                for (int i = 1; i <= 4; i++) // ���� ��ġ���� �ټ� ���� �� Ȯ��
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];
                    //Debug.Log("r: " + row + " c: " + col);

                    if (r >= 0 && r < boardSize && c >= 0 && c < boardSize && m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                    {
                        count++;
                    }
                    else
                        break;
                }
            }

            if (count >= 5)
            {
                return true; // �ټ� ���� ���� �������� ���̸� true ��ȯ
            }
        }

        return false; // �ټ� ���� ���� �������� ������ ������ false ��ȯ
    }
    // �־��� ��ġ���� 3���� ���� ���ӵ� ������ �˻�.
    public bool CheckWin(int player, int row, int col)
    {
        // ���� ������ ũ�� (���� �� ����)
        int boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        // ����, ����, �밢�� ������ Ȯ��
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            int count = 1; // ���� ��ġ�������� count ����

            for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
            {
                for (int i = 1; i <= 4; i++) // ���� ��ġ���� �ټ� ���� �� Ȯ��
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];
                    //Debug.Log("r: " + row + " c: " + col);

                    if (r >= 0 && r < boardSize && c >= 0 && c < boardSize && m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                    {
                        count++;
                        Debug.Log(player + ": " + count);
                    }
                    else
                       break;
                }
            }

            if (count >= 5)
            {
                return true; // �ټ� ���� ���� �������� ���̸� true ��ȯ
            }
        }

        return false; // �ټ� ���� ���� �������� ������ ������ false ��ȯ
    }

    void Start()
    {
        m_currentBoardStateInit = FindObjectOfType<CurrentBoardStateInit>();
    }
}
