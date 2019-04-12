using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Joanna Ho
/// Date: April 01, 2019
/// 
/// This class handles the buying functionality of the shop.
/// it keeps track of the number of fish purcahsed in each category
/// prevents the user from buying if the balance is too low, 
/// and updates the balance 
/// 
/// 0 - turtle
/// 1 - guppy
/// 2 - angelfish
/// 3 - clownfish
/// 4 - discus
/// 5 - squid
/// </summary>
public class BuyStuff : MonoBehaviour
{

    public Action[] buttons;
    public int[] buyCount;
    public ItemInfo[] itemInfo;
    public TextMesh balanceDisplay;
    public int balance = 0;
    //private int petsPurchased = 0;

    void Start()
    {
        String str = balanceDisplay.text.Substring(1);
        balance = Int32.Parse(str);
        buttons = new Action[9];
        buyCount = new int[9];
        buttons[0] = b11OnClick;
        buttons[1] = b12OnClick;
        buttons[2] = b13OnClick;
        buttons[3] = b21OnClick;
        buttons[4] = b22OnClick;
        buttons[5] = b23OnClick;
        buttons[6] = b31OnClick;
        buttons[7] = b32OnClick;
        buttons[8] = b33OnClick;
    }

    void startNewBuyingPhase()
    {
        //petsPurchased = 0;
        String str = balanceDisplay.text.Substring(1);
        balance = Int32.Parse(str);
    }

    int getBalance()
    {
        return balance;
    }

    void purchase(int price)
    {
        if (price <= balance)
        {
            balance -= price;
            Debug.Log("Thanks for purchasing $" + price);
        }
        else
        {
            Debug.Log("You don't have enough money");
        }
    }

    public void updateText()
    {
        Camera.main.GetComponent<Shoot>().money = balance;
        balanceDisplay.text = "$" + balance.ToString();
    }

    //b11 is a fish
    public void b11OnClick()
    {
        buyCount[0]++;
        int price = itemInfo[0].price;
        purchase(price);
        updateText();
    }

    public void b12OnClick()
    {
        buyCount[1]++;
        int price = itemInfo[1].price;
        purchase(price);
        updateText();
    }

    public void b13OnClick()
    {
        buyCount[2]++;
        int price = itemInfo[2].price;
        purchase(price);
        updateText();
    }

    public void b21OnClick()
    {
        buyCount[3]++;
        int price = itemInfo[3].price;
        purchase(price);
        updateText();
    }

    public void b22OnClick()
    {
        buyCount[4]++;
        int price = itemInfo[4].price;
        purchase(price);
        updateText();
    }

    public void b23OnClick()
    {
        buyCount[5]++;
        int price = itemInfo[5].price;
        purchase(price);
        updateText();
    }

    public void b31OnClick()
    {
        buyCount[6]++;
        int price = itemInfo[6].price;
        purchase(price);
        updateText();
    }

    public void b32OnClick()
    {
        buyCount[7]++;
        int price = itemInfo[7].price;
        purchase(price);
        updateText();
    }

    public void b33OnClick()
    {
        buyCount[8]++;
        int price = itemInfo[8].price;
        purchase(price);
        updateText();
    }
}
