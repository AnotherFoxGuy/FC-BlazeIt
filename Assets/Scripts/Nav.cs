// This file is part of FC-BlazeIt
// 
// Copyright (c) 2016 sietze greydanus
// 
// FC-BlazeIt is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License version 3, as
// published by the Free Software Foundation.
// 
// FC-BlazeIt is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with FC-BlazeIt. If not, see <http://www.gnu.org/licenses/>.
// 

using UnityEngine;

public class Nav : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _des;

    // Use this for initialization
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _des = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        _agent.SetDestination(_des);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(_des, _agent.transform.position) < 5)
        {
            _des = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            _agent.SetDestination(_des);
        }
    }
}