using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ӷ� ���� Ŭ����

public class RuleManager : MonoBehaviour
{
    [SerializeField] BoardManager m_boardManager;
    CurrentBoardStateInit m_currentBoardStateInit;


    // ���� ������ ũ�� = 15 (row �� col)
    // start���� m_currentBoardStateInit.m_BoardSize; �ʱ�ȭ
    int m_boardSize;

    // �־��� ��ġ���� 4���� ���� ���ӵ� ������ �˻�.
    static int[] dx = { 0, 1, 1, 1 };
    static int[] dy = { 1, 1, 0, -1 };

    int[] m_stonePos = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

    public int CheckRule(int player, int row, int col)
    {
        if (player == 1 && IsStoneThree(player, row, col))
        {
            return 1;
        }
        //if (player == 1 && IsStoneFour(player, row, col))
        //{
        //    Debug.Log("OOO0");
        //    return 2;
        //}
        //if (player == 1 && IsStoneOver(player, row, col))
        //{
        //    Debug.Log("0OOO00");
        //    return 3;
        //}
        return 0;
    }
    bool IsStoneThree(int player, int row, int col)
    {
        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            string line = "O";
            int count = 0;

            for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
            {
                for (int i = 1; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];

                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
                    {
                        if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                        {
                            // m_stonePos �迭�� r, c �� ����
                            m_stonePos[count * 2] = r;
                            m_stonePos[count * 2 + 1] = c;
                            count++;

                            line += "O";  // �÷��̾��� ���� 'O'
                        }
                        else if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == -1) { } // ��ĭ(-1)�� �� �н�
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
                if (line.Contains("OOO"))
                {
                    Debug.Log("OOO");
                    return IsCheck(player, d, count);  // 'OOO' ������ �߰ߵǸ� True ��ȯ
                }
            }
        }
        return false;
    }
    //bool IsStoneFour(int player, int row, int col)
    //{
    //    for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
    //    {
    //        string line = "";
    //        for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
    //        {
    //            for (int i = -5; i < 6; i++)
    //            {
    //                int r = row + i * dir * dx[d];
    //                int c = col + i * dir * dy[d];


    //                if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
    //                {
    //                    if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
    //                    {
    //                        line += "O";  // �÷��̾��� ���� 'O'
    //                    }
    //                    else
    //                    {
    //                        line += "X";  // ���� ���� 'X'
    //                    }
    //                }
    //                else
    //                {
    //                    line += "X";  // ���� �ٱ��� ��ġ�� 'X'�� ó��
    //                }
    //            }
    //            if (line.Contains("OOOO"))
    //            {
    //                return true;  // 'XOOOOX' ������ �߰ߵǸ� True ��ȯ
    //            }
    //        }
    //    }
    //    return false;
    //}
    //public bool IsStoneOver(int player, int row, int col)
    //{
    //    for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
    //    {
    //        string line = "";
    //        for (int dir = -1; dir <= 1; dir += 2) // �� �������� Ȯ��
    //        {
    //            for (int i = 0; i < 6; i++)
    //            {
    //                int r = row + i * dir * dx[d];
    //                int c = col + i * dir * dy[d];


    //                if (!(0 <= r && r < m_boardSize && 0 <= c && c < m_boardSize))
    //                {
    //                    continue; // ���� �ٱ��� ��ġ�� �������� ó��
    //                }
    //                else if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
    //                {
    //                    line += 'O'; // �÷��̾��� ���� 'O'
    //                }
    //                else
    //                {
    //                    line += 'X'; // ���� ���� 'X'
    //                }
    //            }

    //            if (line.Contains("OOOOOO"))
    //            {
    //                return true; // 'OOOOOO' ������ �߰ߵǸ� True ��ȯ
    //            }
    //        }
    //    }

    //    return false;
    //}

    public bool IsCheck(int player, int excludeDir, int count)
    {
        for (int stonePosArrIndex = 0; stonePosArrIndex < count; stonePosArrIndex++) // ���� ��ǥ�� ���ư��� 
        {
            for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
            {
                if (d == excludeDir)
                    continue;

                string line = "O";

                for (int i = -5; i < 6; i++)
                {

                    int r = m_stonePos[stonePosArrIndex * 2] + i * dx[d];
                    int c = m_stonePos[stonePosArrIndex * 2 + 1] + i * dy[d];

                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
                    {
                        if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                        {
                            line += "O";  // �÷��̾��� ���� 'O'
                        }
                        else if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == -1) { } // ��ĭ(-1)�� �� �н�
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
                if (line.Contains("OOO"))
                {
                    Debug.Log("33");
                    return true;  // 'OOO' ������ �߰ߵǸ� True ��ȯ
                }
            }
        }
        return false;
    }
    //public bool IsDoubleThree(int player, int row, int col)
    //{
    //    if (IsStoneThree(player, row, col))
    //    {
    //        int[] dx = { 0, 1, 1, 1, 2, 2 };
    //        int[] dy = { 1, 0, 1, -1, 2, -2 };
    //    }

    //    int count = 0;
    //    char[][] _board = CopyBoard(board);
    //    _board[row][col] = (char)player;



    //    foreach (var direction in directions)
    //    {
    //        int dx = direction[0];
    //        int dy = direction[1];
    //        int x = row + dx;
    //        int y = col + dy;

    //        if (IsValidIndex(x, y, board.Length))
    //        {
    //            if (board[x][y] == player && IsOpenThree(board, player, x, y))
    //            {
    //                count += 10;
    //            }
    //        }
    //    }

    //    _board[row][col] = '\0';

    //    return count >= 20;
    //}

    //public bool IsDoubleFour(int player, int row, int col)
    //{
    //    if (!IsStoneFour(player, row, col))
    //    {
    //        return false;
    //    }

    //    int count = 0;
    //    char[][] _board = CopyBoard(board);
    //    _board[row][col] = (char)player;

    //    int[][] directions = { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, -1 }, new int[] { 1, 1 }, new int[] { -2, 2 }, new int[] { 2, -2 } };

    //    foreach (var direction in directions)
    //    {
    //        int dx = direction[0];
    //        int dy = direction[1];
    //        int x = row + dx;
    //        int y = col + dy;

    //        if (IsValidIndex(x, y, board.Length))
    //        {
    //            if (board[x][y] == player && IsOpenFour(board, player, x, y))
    //            {
    //                count += 10;
    //            }
    //        }
    //    }

    //    _board[row][col] = '\0';

    //    return count >= 20;
    //}

    //public bool CheckViolation(int player, int row, int col)
    //{
    //    bool doubleThree = IsDoubleThree(player, row, col);
    //    bool doubleFour = IsDoubleFour(player, row, col);
    //    bool overStone = IsStoneOver(player, row, col);

    //    return !(doubleThree || doubleFour || overStone);
    //}
    public bool CheckWin(int player, int row, int col)
    {
        for (int d = 0; d < 4; d++) // 4���� ������ Ȯ��
        {
            int count = 1; // ���� ��ġ�������� count ����
            for (int i = 1; i <= 4; i++) // ���� ��ġ���� �ټ� ���� �� Ȯ��
            {
                int r = row + i * dx[d];
                int c = col + i * dy[d];
                //Debug.Log("r: " + row + " c: " + col);

                if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize && m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                {
                    count++;
                }
                else
                    break;
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

        m_boardSize = m_boardManager.m_BoardSize;
    }
}
