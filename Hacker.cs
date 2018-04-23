using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hacker : MonoBehaviour {

    string username = Environment.UserName;

    int level;

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
    }

    void RunMainMenu(string input) {
        if (input == "1") {
            Terminal.WriteLine("Accessing Library");
            level = 1;
            StartGame();
        }
        else if (input == "2") {
            Terminal.WriteLine("Accessing Police Station");
            level = 2;
            StartGame();
        }
        else if (input == "3") {
            Terminal.WriteLine("Accessing NASA");
            level = 3;
            StartGame();
        }
        else {
            Terminal.WriteLine("Invalid input");
        }
    }

    void StartGame() {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter password ... ");
    }

    // Update is called once per frame
    void Update() {

    }
}
