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

public class Rot : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var o = gameObject.transform.eulerAngles;
        gameObject.transform.eulerAngles = new Vector3(o.x + 0.1f, o.y + 0.1f, o.z + 0.1f);
    }
}