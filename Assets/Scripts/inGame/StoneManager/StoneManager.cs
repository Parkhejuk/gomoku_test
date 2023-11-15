using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Stone Manager Object ���� Ŭ����

public class StoneManager : MonoBehaviour
{
    [SerializeField] GameObject m_gridVertexPrefab;
    [SerializeField] GameObject m_instantedStone;
    [SerializeField] GameObject m_blackStonePrefabs;
    [SerializeField] GameObject m_whiteStonePrefabs;
    [SerializeField] GameObject m_AlphaStonePool;

    [SerializeField] GameObject m_UI;
    [SerializeField] GameObject m_whiteWinUIPrefabs;
    [SerializeField] GameObject m_BlackWinUIPrefabs;

    CurrentBoardStateInit m_currentBoardStateInit;
    RuleManager m_ruleManager;
    public RaycastHit hit;

    //isOrder 1(true)�� ����, 1(true)�� �浹, 0(false)�� �鵹 & player ����
    bool m_isOrder = true;
    static bool m_isBlackStone = true;
    static bool m_isWhiteStone = false;

    //�ٸ� ��ũ��Ʈ���� ����� ���� ������Ƽ
    public bool m_IsOrder { get { return m_isOrder; } set { m_isOrder = value; } }

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

                        //isOrder�� true(1)�� �� �浹, false(0)�� �� �鵹
                        var obj = Instantiate(m_isOrder ? m_blackStonePrefabs : m_whiteStonePrefabs, hit.collider.bounds.center, Quaternion.identity);
                        obj.transform.SetParent(m_instantedStone.transform);
                        m_currentBoardStateInit.UpdateBoardState(obj);

                        int player = m_isOrder ? 1 : 0;
                        m_ruleManager.CheckRule(player, m_currentBoardStateInit.m_Row, m_currentBoardStateInit.m_Col);

                        // Black/White Win ���â ����
                        if (m_ruleManager.CheckWin(player, m_currentBoardStateInit.m_Row, m_currentBoardStateInit.m_Col))
                        {
                            var UIobj = Instantiate(m_isOrder ? m_BlackWinUIPrefabs : m_whiteWinUIPrefabs);
                            UIobj.transform.SetParent(m_UI.transform);
                            UIobj.transform.position = new Vector3(645, 1398, 0);
                            UIobj.GetComponent<RectTransform>().sizeDelta = new Vector3(1600, 4000);
                        }

                        m_isOrder = m_isOrder ? m_isWhiteStone : m_isBlackStone;
                    }
                }
            }
        }
    }
}
