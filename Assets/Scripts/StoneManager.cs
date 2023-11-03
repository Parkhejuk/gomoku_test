using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    [SerializeField] GameObject m_gridVertexPrefab;
    [SerializeField] GameObject m_instantedStone;
    [SerializeField] GameObject m_blackStonePrefabs;
    [SerializeField] GameObject m_whiteStonePrefabs;
    [SerializeField] GameObject m_AlphaStonePool;

    //isOrder 1(true)�� ����, 1(true)�� �浹, 0(false)�� �鵹
    //�ٸ� Script���� isOrder�� ����ϱ� ���� ������Ƽ
    bool m_isOrder = true;
    static bool m_isBlackStone = true;
    static bool m_isWhiteStone = false;

    public bool m_IsOrder { get { return m_isOrder; } set { m_isOrder = value; } }

    public RaycastHit hit;
    RuleManager m_ruleManager;

    private void Start()
    {
        m_ruleManager = FindObjectOfType<RuleManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (RayCastUtil.RaycastFromMouse(out hit))
            {
                if (hit.collider.gameObject.tag == "Stone") // Ư�� ��ġ ���� ������Ʈ �ߺ� ���� ����
                {
                    Debug.Log("�� �ڸ����� �ٵϵ��� �ֽ��ϴ�.");
                }
                else if (hit.collider.gameObject.tag != "Stone")
                {
                    //isOrder�� true(1)�� �� �浹, false(0)�� �� �鵹
                    var obj = Instantiate(m_isOrder ? m_blackStonePrefabs : m_whiteStonePrefabs, hit.collider.bounds.center, Quaternion.identity);
                    obj.transform.SetParent(m_instantedStone.transform);
                    m_isOrder = m_isOrder ? m_isWhiteStone : m_isBlackStone;

                    m_ruleManager.UpdateBoardState();

                }
            }
        }
    }
}
