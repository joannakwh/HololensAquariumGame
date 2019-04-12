// ===============================
// AUTHOR     : Joanna Ho
// CREATE DATE     : 03/20/2019
// PURPOSE     : This class is the definition of an object
//      for a single shop item. It has the attributes itemInfo, 
//      tagText for displaying the information in game, and 
//      the sprite image. On Start, it initializes the values 
//      pulled from the scriptable object to the associated gameObject.
//
// REFERENCES   : 
// https://www.youtube.com/watch?v=aPXvoWVabPY&t=4s
// ===============================
// Change History:
//
//==================================
using UnityEngine;

public class Item : MonoBehaviour {

    public ItemInfo itemInfo;
    public TextMesh tagText;
    public SpriteRenderer spriteR;
    // Use this for initialization
    void Start () {
        spriteR.sprite = itemInfo.artwork;
        tagText.text = itemInfo.name + "\n $" + itemInfo.price;

    }
}
