using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stone Manager Object 메인 클래스

public class StoneManager : MonoBehaviour
{
    [SerializeField] GameObject m_gridVertexPrefab;
    [SerializeField] GameObject m_instantedStone;
    [SerializeField] GameObject m_blackStonePrefabs;
    [SerializeField] GameObject m_whiteStonePrefabs;
    [SerializeField] GameObject m_AlphaStonePool;

    CurrentBoardStateInit m_currentBoardStateInit;
    RuleManager m_ruleManager;
    public RaycastHit hit;

    //isOrder 1(true)로 시작, 1(true)은 흑돌, 0(false)은 백돌 & player 정보
    bool m_isOrder = true;
    static bool m_isBlackStone = true;
    static bool m_isWhiteStone = false;

    //다른 스크립트에서 사용할 변수 프로퍼티
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

            if (RayCastUtil.RaycastFromMouse(out hit))
            {
                if (hit.collider.gameObject.tag == "Stone") // 특정 위치 스톤 오브젝트 중복 생성 제한
                {
                    Debug.Log("이 자리에는 바둑돌이 있습니다.");
                }
                else if (hit.collider.gameObject.tag != "Stone")
                {
                    //isOrder가 true(1)일 때 흑돌, false(0)일 때 백돌
                    var obj = Instantiate(m_isOrder ? m_blackStonePrefabs : m_whiteStonePrefabs, hit.collider.bounds.center, Quaternion.identity);
                    obj.transform.SetParent(m_instantedStone.transform);

                    m_currentBoardStateInit.UpdateBoardState(obj);

                    int player = m_isOrder ? 1 : 0;
                    m_ruleManager.CheckRule(player, m_currentBoardStateInit.m_Row, m_currentBoardStateInit.m_Col);
                                        
                    m_isOrder = m_isOrder ? m_isWhiteStone : m_isBlackStone;
                }
            }
        }
    }
}
