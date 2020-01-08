﻿using System;
using System.Collections.Generic;

namespace Dice
{
    class Program
    {
        //Public string that cannot be changed
        public const string TITLE = " | GP-1-TheDice | Data & Kommunikation TECHCOLLEGE";
        //The program entry method (The main method)
        static void Main(string[] args)
        {

            Console.WriteLine("Task: GP-1-TheDice"+TITLE);
            Console.WriteLine("======================");
            Console.WriteLine("Press a key to begin");
            Console.ReadKey();
            //IDice dice = new YOUR_DICE();
            //UserInterface.AddAvailableDice(YOUR_DICE);
            UserInterface.Create();
        }
        
    }
    /**
    DO NOT MODIFY UserInterface
    This is the user interface. It takes commands from user and displays user choices.
    **/
    class UserInterface {
        IDice dice;
        static List<IDice> available = new List<IDice>();
        string diceName {get { return (dice == null) ? "none" : dice.Name();}}
        //Create a user interface and starts it
        public static void Create() {
            UserInterface ui = new UserInterface();
            //Start by showing the menu
            ui.menu();
        }
        //Got a new type of dice - add it to the system;
        public static void AddAvailableDice(IDice newAvailableDice) {
            available.Add(newAvailableDice);
        }
        //Show the menu interface
        protected void menu() {
            Console.Clear();
            Console.WriteLine("Menu"+Program.TITLE);
            Console.WriteLine("======================");
            Console.WriteLine("1. Choose dice [current: "+diceName+"]");
            Console.WriteLine("2. Roll dice");
            Console.WriteLine("3. Quit");
            var command = getNumber();
            switch (command) {
                case 1:
                    //Choose dice
                    chooseDice();
                    //And return to menu
                    menu();
                    break;
                case 2:
                    //Roll dice and show result
                    rollDice();
                    //Return to menu
                    menu();
                    break;
                case 3:
                    //Return from menu and quit the program
                    return;
                default:
                    //Show menu by default
                    menu();
                    break;
            }
        }
        //Show the choose dice interface for letting user choose a dice
        protected void chooseDice() {
            
            Console.Clear();
            Console.WriteLine("Menu > Choose Dice"+Program.TITLE);
            Console.WriteLine("======================");
            if (available.Count == 0) {
                pressAnyKey("There are no available dices. You must first create a class and add it with UserInterface.AddAvailableDice()");
                return;
            }

            //Show each available dice here as an option
            for (int choiceNum = 1;choiceNum <= available.Count; choiceNum++) {
                string text = string.Format("{0}. {1}",choiceNum,available[choiceNum-1].Name());
                Console.WriteLine(text);
            }

            //Get the choice from the user
            int command = getNumber();
            while (command > available.Count || command < 0) {
                Console.WriteLine("Not a valid choice");
            }

            //Set the dice the user chose
            dice = available[command-1];
        }
        protected void rollDice() {
            Console.Clear();
            Console.WriteLine("Menu > Roll Dice"+Program.TITLE);
            Console.WriteLine("======================");

            if (dice != null) {
                Console.WriteLine("Press Enter to reroll the "+dice.Name()+" again");
                //As long as the user presses enter - keep rerolling
                while (Console.ReadKey().Key == ConsoleKey.Enter) {
                    Console.WriteLine("You got "+dice.Roll());
                }
                //Return to main menu
                menu();
            } else {
                pressAnyKey("First choose a dice. Press any key to return to menu");
            }
        }
        //Get a number from user. If user writes something that is not a number - keep trying
        protected int getNumber(string hint="$") {
            
            if (!string.IsNullOrEmpty(hint))
                Console.Write(hint+">");

            string str = Console.ReadLine();
            
            //Attempt to convert int to string and store the value in the num variable
            int num;
            while (!int.TryParse(str, out num)) {
                Console.WriteLine("Not a number");

                if (!string.IsNullOrEmpty(hint))
                    Console.Write(hint+">");
                str = Console.ReadLine();
            }
            return num;
        }
        //Shows a message and await user key press to continue
        protected void pressAnyKey(string msg) {
            Console.WriteLine(msg);
            Console.ReadKey();
        }
    }
}
