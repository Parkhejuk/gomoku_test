using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임룰 관련 클래스

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
        // 주어진 위치에서 3개의 돌이 연속된 패턴을 검사.
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // 오목 보드의 크기 (가로 및 세로)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4개의 방향을 확인
        {
            string line = "";
            for (int dir = -1; dir <= 1; dir += 2) // 양 방향으로 확인
            {
                for (int i = -5; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];

                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
                    {
                        if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                        {
                            line += "O";  // 플레이어의 돌은 'O'
                        }
                        else
                        {
                            line += "X";  // 상대방 돌은 'X'
                        }
                    }
                    else
                    {
                        line += "X";  // 보드 바깥의 위치는 'X'로 처리
                    }
                }
                if (line.Contains("XOOOX"))
                {
                    return true;  // 'XOOOX' 패턴이 발견되면 True 반환
                }
            }
        }
        return false;
    }
    bool IsStoneFour(int player, int row, int col)
    {
        // 주어진 위치에서 4개의 돌이 연속된 패턴을 검사.
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // 오목 보드의 크기 (가로 및 세로)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4개의 방향을 확인
        {
            string line = "";
            for (int dir = -1; dir <= 1; dir += 2) // 양 방향으로 확인
            {
                for (int i = -5; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];


                    if (r >= 0 && r < m_boardSize && c >= 0 && c < m_boardSize)
                    {
                        if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                        {
                            line += "O";  // 플레이어의 돌은 'O'
                        }
                        else
                        {
                            line += "X";  // 상대방 돌은 'X'
                        }
                    }
                    else
                    {
                        line += "X";  // 보드 바깥의 위치는 'X'로 처리
                    }
                }
                if (line.Contains("XOOOOX"))
                {
                    return true;  // 'XOOOOX' 패턴이 발견되면 True 반환
                }
            }
        } 
        return false;
    }
    public bool IsStoneOver(int player, int row, int col)
    {
        // 주어진 위치에서 4개의 돌이 연속된 패턴을 검사.
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // 오목 보드의 크기 (가로 및 세로)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4개의 방향을 확인
        {
            string line = "";
            for (int dir = -1; dir <= 1; dir += 2) // 양 방향으로 확인
            {
                for (int i = -5; i < 6; i++)
                {
                    int r = row + i * dir * dx[d];
                    int c = col + i * dir * dy[d];


                    if (!(0 <= r && r < m_boardSize && 0 <= c && c < m_boardSize))
                    {
                        continue; // 보드 바깥의 위치는 공백으로 처리
                    }
                    else if (m_currentBoardStateInit.m_CurrentBoardState[r, c] == player)
                    {
                        line += 'O'; // 플레이어의 돌은 'O'
                    }
                    else
                    {
                        line += 'X'; // 상대방 돌은 'X'
                    }
                }

                if (line.Contains("OOOOOO"))
                {
                    return true; // 'OOOOOO' 패턴이 발견되면 True 반환
                }
            }
        }

        return false;
    }
    public bool CheckWin(int player, int row, int col)
    {
        // 가로, 세로, 대각선 방향을 확인
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

        // 오목 보드의 크기 (가로 및 세로)
        int m_boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        for (int d = 0; d < 4; d++) // 4개의 방향을 확인
        {
            int count = 1; // 현재 위치에서부터 count 시작

            for (int dir = -1; dir <= 1; dir += 2) // 양 방향으로 확인
            {
                for (int i = 1; i <= 4; i++) // 현재 위치에서 다섯 개의 돌 확인
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
                return true; // 다섯 개의 돌이 연속으로 놓이면 true 반환
            }
        }

        return false; // 다섯 개의 돌이 연속으로 놓이지 않으면 false 반환
    }

    void Start()
    {
        m_currentBoardStateInit = FindObjectOfType<CurrentBoardStateInit>();
    }
}
