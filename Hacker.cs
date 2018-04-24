using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hacker : MonoBehaviour {

    const string menuHint = "Type 'menu' to return.";
    // Game config
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "shotgun", "handcuffs", "badge", "uniform", "law", "order" };
    string[] level3Passwords = { "space", "elon", "rocketship", "spaceman", "starman", "spidersfrommars" };

    // Game state
    string username = Environment.UserName;
    int level;
    string password;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

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
            DisplayWinScreen();
        }
        else {
            StartGame();
            Terminal.WriteLine("Try Again");
        }
    }

    void StartGame() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword() {
        switch (level) {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward() {
        switch (level) {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
      __        __      
     /\ \      /\ \ 
    /  \ \    /  \ \ 
   / /\ \ \  / /\ \ \ 
  / / /\ \ \/ / /\ \ \  
 / / /__\_\/ / /__\_\ \ 
/ / /______\/ /________\
\/_____________________/
                ");
                break;
            case 2:
                Terminal.WriteLine("Get out of jail ...");
                Terminal.WriteLine(@"
  ooo,    .---.
 o`  o   /    |\________________
o`   'oooo()  | ________   _   _)
`oo   o` \    |/        | | | |
  `ooo'   `---'         |_| |_|
                ");
                break;
            case 3:
                Terminal.WriteLine("Tickets to Mars!");
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                ");
                break;
            default:
                Debug.LogError("You should not be geting this error.");
                break;
        }
    }

    void RunMainMenu(string input) {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber) {
            level = int.Parse(input);
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
