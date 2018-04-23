using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hacker : MonoBehaviour {

    string username = Environment.UserName;

    int level;
    string password;

    enum Screen { MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;

    // Use this for initialization
    void Start () {
        ShowMainMenu(username); 

    }

    void ShowMainMenu(string user) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + user + "\n" +
            "Press 1 for Library\n" +
            "Press 2 for Police Station\n" +
            "Press 3 for NASA\n" +
            "Type 'menu' to return\n" +
            "Enter the number of your selection:");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu(username);
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void CheckPassword(string input) {
        if (input == password) {
            Terminal.WriteLine("Success");
        }
        else {
            Terminal.WriteLine("Try Again");
        }
    }

    void StartGame() {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter password ... ");
    }

    void RunMainMenu(string input) {
        if (input == "1") {
            Terminal.WriteLine("Accessing Library");
            level = 1;
            password = "books";
            StartGame();
        }
        else if (input == "2") {
            Terminal.WriteLine("Accessing Police Station");
            level = 2;
            password = "handcuffs";
            StartGame();
        }
        else if (input == "3") {
            Terminal.WriteLine("Accessing NASA");
            level = 3;
            password = "antigravity";
            StartGame();
        }
        else {
            Terminal.WriteLine("Invalid input");
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
