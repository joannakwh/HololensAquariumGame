// ===============================
// AUTHOR     : Joanna Ho
// CREATE DATE     : 03/07/2019
// PURPOSE     : This class is a scriptable object.
//    It holds the data members for each shop item,
//    including the name of the fish, its' price and
//    Sprite image. 
// REFERENCES   : 
// https://www.youtube.com/watch?v=aPXvoWVabPY&t=4s
// ===============================
// Change History:
//
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemInfo : ScriptableObject {
    public new string name;
    public Sprite artwork;
    public int price;
}
