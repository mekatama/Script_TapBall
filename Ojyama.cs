using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojyama : MonoBehaviour
{
    public bool isRotation; //回転flag
    public int rot_x;       //回転値
    public int rot_y;       //
public int rot_z;       //

    void Update(){
        if(isRotation){
    		transform.Rotate(new Vector3(rot_x, rot_y, rot_z) * Time.deltaTime);
        }
    }
}
