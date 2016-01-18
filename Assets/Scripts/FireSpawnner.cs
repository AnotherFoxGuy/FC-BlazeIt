using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireSpawnner : MonoBehaviour
{
    public List<FireObjects> ActiveFire;
    public List<FireObjects> InactiveFire;
    private int _amountOfActiveFire;
    private NavMeshAgent _player;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        var sp = GameObject.FindGameObjectsWithTag("SpawnPoints");
        for (var i = 0; i < sp.Length; i++)
        {
            var o = sp[i].GetComponent<FireObjects>();
            o.Pool = this;
            InactiveFire.Add(o);
        }
        Update();
        //_player.SetDestination(GetClosest());
    }

    // Update is called once per frame
    void Update()
    {
        if (_amountOfActiveFire < 2)
        {
            var o = InactiveFire[Mathf.RoundToInt(Random.Range(0, InactiveFire.Count))];
            o.ParticleSystem.gameObject.SetActive(true);
            o.ResetThis();
            ActiveFire.Add(o);
            InactiveFire.Remove(o);
            _amountOfActiveFire = ActiveFire.Count;
            _player.SetDestination(GetClosest());
        }
    }

    public void DestroyFire(FireObjects obj)
    {
        obj.ParticleSystem.gameObject.SetActive(false);
        InactiveFire.Add(obj);
        ActiveFire.Remove(obj);
        _amountOfActiveFire = ActiveFire.Count;    
    }

    Vector3 GetClosest()
    {
        var tMin = new Vector3();
        var minDist = Mathf.Infinity;
        var currentPos = _player.transform.position;
        //print("ActiveFire.Count " + ActiveFire.Count);
        foreach (var af in ActiveFire)
        {
            float dist = Vector3.Distance(af.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = af.transform.position;
                minDist = dist;
            }
            //print("Dis = " + dist + " | minDis = " + minDist);
        }
        return tMin;
    }
}