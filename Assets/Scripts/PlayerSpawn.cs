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

public class PlayerSpawn : MonoBehaviour
{
    private Transform _setpos;
    public GameObject Cardboard;
    public GameObject Dive;

    public void Awake()
    {
        _setpos = Cardboard.transform;
        /*
        var i = PlayerPrefs.GetInt("VRMode");

        switch (i)
        {
            case 0:
                Cardboard.SetActive(true);
                Dive.SetActive(false);
                _setpos = Cardboard.transform;
                break;
            case 1:
                Cardboard.SetActive(false);
                Dive.SetActive(true);
                _setpos = Dive.transform;
                break;
            default:
                Cardboard.SetActive(true);
                Dive.SetActive(false);
                _setpos = Cardboard.transform;
                break;
        }
        */
    }

    public void Update()
    {
        _setpos.position = transform.position;
    }
}