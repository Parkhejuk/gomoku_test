using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ӷ� ���� Ŭ����

public class RuleManager : MonoBehaviour
{
    CurrentBoardStateInit m_currentBoardStateInit;

    public int CheckRule(int player, int row, int col)
    {
        if(player == 1 && IsStoneThree(player, row, col))
        {
            Debug.Log("XOOOX");
            return 5;
        }
        if (player == 1 && IsStoneFour(player, row, col))
        {
            Debug.Log("XOOO0X");
            return 7;
        }
        if (player == 1 && IsStoneOver(player, row, col))
        {
            Debug.Log("0OOO00");
            return 3;
        }
        return 0;
    }
    bool IsStoneThree(int player, int row, int col)
    {
        // �־��� ��ġ���� 3���� ���� ���ӵ� ������ �˻�.
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // ���� ������ ũ�� (���� �� ����)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            string line = "";
            for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
            {
                for (int i = -5; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];

                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
                    {
                        if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                        {
                            line += "O";  // �÷��̾��� ���� 'O'
                        }
                        else
                        {
                            line += "X";  // ���� ���� 'X'
                        }
                    }
                    else
                    {
                        line += "X";  // ���� �ٱ��� ��ġ�� 'X'�� ó��
                    }
                }
                if (line.Contains("XOOOX"))
                {
                    return true;  // 'XOOOX' ������ �߰ߵǸ� True ��ȯ
                }
            }
        }
        return false;
    }
    bool IsStoneFour(int player, int row, int col)
    {
        // �־��� ��ġ���� 4���� ���� ���ӵ� ������ �˻�.
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // ���� ������ ũ�� (���� �� ����)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            string line = "";
            for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
            {
                for (int i = -5; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];


                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
                    {
                        if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                        {
                            line += "O";  // �÷��̾��� ���� 'O'
                        }
                        else
                        {
                            line += "X";  // ���� ���� 'X'
                        }
                    }
                    else
                    {
                        line += "X";  // ���� �ٱ��� ��ġ�� 'X'�� ó��
                    }
                }
                if (line.Contains("XOOOOX"))
                {
                    return true;  // 'XOOOOX' ������ �߰ߵǸ� True ��ȯ
                }
            }
        } 
        return false;
    }
    public bool IsStoneOver(int player, int row, int col)
    {
        // �־��� ��ġ���� 4���� ���� ���ӵ� ������ �˻�.
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // ���� ������ ũ�� (���� �� ����)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            string line = "";
            for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
            {
                for (int i = -5; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];


                    if (!(0 <= r && r < m_boardSize && 0 <= c && c < m_boardSize))
                    {
                        continue; // ���� �ٱ��� ��ġ�� �������� ó��
                    }
                    else if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                    {
                        line += 'O'; // �÷��̾��� ���� 'O'
                    }
                    else
                    {
                        line += 'X'; // ���� ���� 'X'
                    }
                }

                if (line.Contains("OOOOOO"))
                {
                    return true; // 'OOOOOO' ������ �߰ߵǸ� True ��ȯ
                }
            }
        }

        return false;
    }
    public bool CheckWin(int player, int row, int col)
    {
        // ����, ����, �밢�� ������ Ȯ��
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // ���� ������ ũ�� (���� �� ����)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

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

                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize && m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
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

    void Start()
    {
        m_currentBoardStateInit = FindObjectOfType<CurrentBoardStateInit>();
    }
}
