using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "sargeant", "helicopter", "arsenal", "grenade" };
    private int level;
    private string password;

    enum Screen { MainMenu, Password, Win }
    private Screen currentScreen = Screen.MainMenu;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the Army");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            Terminal.WriteLine("Type `menu` to restart");
        }
    }

    void RunMainMenu(string input)
    {
        var validLevel = (input == "1" || input == "2" || input == "3");
        if (validLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void CheckPassword(string password)
    {
        if (this.password == password)
        {
            WinGame();
        }
        else
        {
            AskForPassword();
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void WinGame()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void SetRandomPassword()
    {
        string[] passwords = { };
        switch (level)
        {
            case 1:
                passwords = level1Passwords;
                break;
            case 2:
                passwords = level2Passwords;
                break;
            case 3:
                passwords = level3Passwords;
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        var index = UnityEngine.Random.Range(0, passwords.Length);
        password = passwords[index];
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ______
   /     //
  /     //
 /_____//
(_____(/
"
                );
                break;
            case 2:
            Terminal.WriteLine(@"
              ,
     __  _.-'` `'-.
    /||\'._ __{}_(
    ||||  |'--.__\
    |  L.(   ^_\^
    \ .-' |   _ |
    | |   )\___/
    |  \-'`:._]
jgs \__/;      '-.
"
            );
                break;
            case 3:
            Terminal.WriteLine(@"
   |\
   || .---.
   ||/_____\
   ||( '.' )
   || \_-_/_
   :-'`'V'//-.
  / ,   |// , `\
 / /|Ll //Ll|| |
/_/||__//   || |
\ \/---|[]==|| |
            "
            );
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}
