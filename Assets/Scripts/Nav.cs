using UnityEngine;
using System.Collections;

public class Nav : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _des;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _des = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        _agent.SetDestination(_des);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_des,_agent.transform.position) < 5)
        {
            _des = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            _agent.SetDestination(_des);
        }
    }
}
