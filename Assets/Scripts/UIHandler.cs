using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This class manages the user interface 
/// Author: Joanna Ho
/// Date: April 01, 2019
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class UIHandler : MonoBehaviour {
    private const float secondsInRound = 180f;
    public Text levelText, timer, money, fish;

    public int level, fishCount, balance;

    public float timeLeft;

    public AudioSource audioData;

    // Use this for initialization
    void OnStart () {
        setFish(4);
        setMoney(0);
        timeLeft = secondsInRound;
        audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timer.text = Math.Round(timeLeft).ToString();
        if(timeLeft < 0)
        {
            increaseLevel();
            timeLeft = secondsInRound;
            audioData.Play(0);
        }
    }
    public void increaseLevel()
    {
        level++;
        levelText.text = "LEVEL: " + level;
    }

    public void setLevel(int number)
    {
        level = number;
        levelText.text = "LEVEL: " + level;
    }

    public int getLevel()
    {
        return level;
    }

    public void setMoney(int amount)
    {
        balance = amount;
        money.text = "$" + amount.ToString();
    }

    public int getMoney()
    {
        return balance;
    }

    public void setFish(int number)
    {
        fishCount = number;
        fish.text = number.ToString() + "x";
    }

    public int getFish()
    {
        return fishCount;
    }

}
