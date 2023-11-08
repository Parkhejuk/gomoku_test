using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임룰 관련 클래스

public class RuleManager : MonoBehaviour
{
    CurrentBoardStateInit m_currentBoardStateInit;

    public void CheckRule(int player, int row, int col)
    {
        if (CheckWin(player, row, col))
        {
            if (player == 1)
                Debug.Log("게임종료\n 흑 승리!");
            else
                Debug.Log("게임종료\n 백 승리!");
        }
    }
    public bool CheckBlack43(int player, int row, int col)
    {
        // 오목 보드의 크기 (가로 및 세로)
        int boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        // 가로, 세로, 대각선 방향을 확인
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

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
                return true; // 다섯 개의 돌이 연속으로 놓이면 true 반환
            }
        }

        return false; // 다섯 개의 돌이 연속으로 놓이지 않으면 false 반환
    }
    // 주어진 위치에서 3개의 돌이 연속된 패턴을 검사.
    public bool CheckWin(int player, int row, int col)
    {
        // 오목 보드의 크기 (가로 및 세로)
        int boardSize = m_currentBoardStateInit.m_CurrentBoardState.GetLength(0);

        // 가로, 세로, 대각선 방향을 확인
        int[] dx = { 0, 1, 1, 1 };
        int[] dy = { 1, 0, 1, -1 };

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
