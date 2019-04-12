// ===============================
// AUTHOR     : Joanna Ho
// CREATE DATE     : 03/23/2019
// PURPOSE     : This class is an eventhandler for when a shop item is clicked.
//      It takes the string data from the balance textMesh and converts it into 
//      an integer. When a shop item button is pressed, the cost of the item is 
//      compared to see if there is enough money to buy it. If there is, the 
//      money is subtracted and updated to the textMesh
//
// REFERENCES   : 
// ===============================
// Change History:
//
//==================================

using UnityEngine;
using UnityEngine.UI;
using System;

public class onClickBuy : MonoBehaviour
{
    public Button button;
    public ItemInfo itemInfo;
    //public Balance balInfo;
    public TextMesh balanceDisplay;
    private int balance = 0;
    private int price = 0;

    void Start()
    {
        String str = balanceDisplay.text.Substring(1);
        balance = Int32.Parse(str);
        button.onClick.AddListener(TaskOnClick);
        price = itemInfo.price;
    }

    void TaskOnClick()
    {

        if (price > balance)
        {
            Debug.LogWarning("You don't have enough money to purchase this item!");
        }
        else
        {
            balance -= price;
            Debug.LogWarning("You have just purchased something for $" + price);
        }

        balanceDisplay.text = "$" + balance.ToString();
    }
}