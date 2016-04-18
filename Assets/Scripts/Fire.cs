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

public class Fire : MonoBehaviour
{
    private bool _on;
    private ParticleSystem _particleSystem;
    private bool _set;

    public void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformVector(Vector3.forward));
        var col = Physics.Raycast(transform.position, transform.TransformVector(Vector3.forward), out hit);

        if (col && hit.collider.tag == "SpawnPoints")
            _set = true;
        else
            _set = false;

        if (_set != _on)
        {
            if (_set)
                _particleSystem.Play();
            else
                _particleSystem.Stop();
            _on = _set;
        }
    }
}