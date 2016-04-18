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
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool _on;
    private float _timer;
    public Image Credits;
    public Image Loading;

    public void Start()
    {
        Loading.enabled = false;
        Credits.enabled = false;
    }

    public void Update()
    {
        if (_timer > 0) _timer -= Time.deltaTime;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Raycheck(Camera.main.ScreenPointToRay(Input.mousePosition));
        }
#else
        if (Input.touchCount > 0)
        {
            Raycheck(Camera.main.ScreenPointToRay(Input.GetTouch(0).position));
        }
#endif
    }

    private void Raycheck(Ray ray)
    {
        if (_on && _timer < 0.1)
        {
            print("Credits");
            _on = false;
            Credits.enabled = false;
        }
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Menu"))
        {
            var r = hit.collider.GetComponent<Rigidbody>();
            if (r != null)
                r.AddExplosionForce(200, hit.point + hit.normal, 3);
            switch (hit.collider.name)
            {
                case "Play":
                    Loading.enabled = true;
                    SceneManager.LoadScene(1);
                    break;
                case "Credits":
                    print("Credits");
                    _on = true;
                    Credits.enabled = true;
                    _timer = 0.21f;
                    break;
            }
        }
    }
}