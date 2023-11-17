using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Stone Manager Object ���� Ŭ����

public class StoneManager : MonoBehaviour
{
    [SerializeField] GameObject m_instantedStone; //StonePrefab ������Ʈ�� ���� �θ� ������Ʈ
    [SerializeField] GameObject m_blackStonePrefabs;
    [SerializeField] GameObject m_whiteStonePrefabs;
    [SerializeField] GameObject m_emptyObject;

    [SerializeField] GameObject m_UI;
    [SerializeField] GameObject m_whiteWinUIPrefabs;
    [SerializeField] GameObject m_BlackWinUIPrefabs;

    CurrentBoardStateInit m_currentBoardStateInit;
    RuleManager m_ruleManager;
    public RaycastHit hit;

    //isOrder 1(true)�� ����, 1(true)�� �浹, 0(false)�� �鵹 & player ����
    bool m_player = true;
    bool m_isStoneThree = false;
    static bool m_isBlackStone = true;
    static bool m_isWhiteStone = false;

    //�ٸ� ��ũ��Ʈ���� ����� ���� ������Ƽ
    public bool m_IsPlayer { get { return m_player; } set { m_player = value; } }

    void Start()
    {
        m_currentBoardStateInit = FindObjectOfType<CurrentBoardStateInit>();
        m_ruleManager = FindObjectOfType<RuleManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //UI ������ ���콺 �̺�Ʈ ����
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    // Ư�� ��ġ ���� ������Ʈ �ߺ� ���� ����
                    if (hit.collider.gameObject.tag == "Stone")
                    {
                        Debug.Log("�� �ڸ����� �ٵϵ��� �ֽ��ϴ�.");
                    }
                    else if (hit.collider.gameObject.tag != "Stone")
                    {
                        int player = m_player ? 1 : 0;
                        //m_playerr�� true(1)�� �� �浹, false(0)�� �� �鵹
                        var obj = Instantiate(m_emptyObject, hit.collider.bounds.center, Quaternion.identity);
                        obj.transform.SetParent(m_instantedStone.transform);
                        m_currentBoardStateInit.UpdateBoardState(obj, hit, m_player);


                        int CheckRule = m_ruleManager.CheckRule(player, m_currentBoardStateInit.m_Row, m_currentBoardStateInit.m_Col);

                        switch (CheckRule)
                        {
                            case 1:
                                Debug.Log("33�Դϴ�. �� �ڸ��� �� �� �����ϴ�.");
                                m_isStoneThree = true;
                                break;

                            //case 4:
                            //    Debug.Log("����Դϴ�. �� �ڸ��� �� �� �����ϴ�.");
                            //    break;

                            default:
                                obj = Instantiate(m_player ? m_blackStonePrefabs : m_whiteStonePrefabs, hit.collider.bounds.center, Quaternion.identity);
                                obj.transform.SetParent(m_instantedStone.transform);
                                break;
                        }

                        // Black/White Win ���â ����
                        if (m_ruleManager.CheckWin(player, m_currentBoardStateInit.m_Row, m_currentBoardStateInit.m_Col))
                        {
                            var UIobj = Instantiate(m_player ? m_BlackWinUIPrefabs : m_whiteWinUIPrefabs);
                            UIobj.transform.SetParent(m_UI.transform);
                            UIobj.transform.position = new Vector3(645, 1398, 0);
                            UIobj.GetComponent<RectTransform>().sizeDelta = new Vector3(1600, 4000);
                        }

                        if (!m_isStoneThree)
                        {
                            m_player = m_player ? m_isWhiteStone : m_isBlackStone;
                            m_isStoneThree = false;
                        }
                    }
                }
            }
        }
    }
}
