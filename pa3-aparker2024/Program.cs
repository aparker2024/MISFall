
int computerWins = 0;
int userWins = 0;
int gil = 50;


StartUp(ref gil, ref computerWins, ref userWins);
///////////////////////////////////////////////////////////////////// END MAIN ////////////////////////////////////////////////////////////////////////////////////////////////////////////

static void StartUp(ref int gil, ref int computerWins, ref int userWins)
{
    Console.Clear();
    System.Console.WriteLine("Welcome to \nJEFF'S JOLLY JACKPOT LAND!!!!!");
    System.Console.WriteLine("Here you will be able to play two games");
    System.Console.WriteLine("1. Slot Machines \n2. Black Jack\n3. ScoreBoard\n4. Exit");
 
    int userNum = GetMenuChoice(); 
    if (userNum >= 1 && userNum <= 5)
    {
        if (userNum == 1)
        {
            IntroSlotMachine(ref gil);
        }
        else if (userNum == 2)
        {
            BlackJackStartUp(ref gil);
        }
       else if (userNum == 3)
        {
            ScoreBoard(ref gil, ref computerWins, ref userWins);
        }
        else if (userNum == 4)
        {
            ExitProgram(ref gil);
        }
    }


}

static int GetMenuChoice()
{
    int menuChoice = int.Parse(Console.ReadLine());

    while (menuChoice < 1 || menuChoice > 4 ) // error handling
    {
        System.Console.WriteLine("Invalid Menu Choice");
        System.Console.WriteLine("Enter A valid option ");
        
        menuChoice = int.Parse(Console.ReadLine());
    }
    return menuChoice;
}


static void IntroSlotMachine(ref int gil)
{
    
    System.Console.WriteLine($"you have {gil} gil to start");
    System.Console.WriteLine("enter the amount you would like to risk");
    int slotGilRisk = int.Parse(Console.ReadLine());

    while (slotGilRisk > 0)
    {
        if(slotGilRisk < gil)
        {
        System.Console.WriteLine($"you will have about {gil - slotGilRisk} left are you sure you would like to continue?  (yes or no)");
        string confirmSlotRisk = Console.ReadLine();

        if (confirmSlotRisk.ToUpper() == "YES")
        {
            gil -= slotGilRisk;
            SlotStartUp(ref gil, ref slotGilRisk);
        }
        else
        {
            System.Console.WriteLine("You will now exit the system ");
            ExitProgram(ref gil);

        }
       }

    if (slotGilRisk == gil)
    {
        System.Console.WriteLine("you are about to go ALL IN.\nAre you sure would you like to contine?  (yes or no)");
        string confirmAllinRisk = Console.ReadLine();

        if (confirmAllinRisk.ToUpper() == "YES")
        {
            gil -= slotGilRisk;
            SlotStartUp(ref gil, ref slotGilRisk);
        }
        else
        {
            System.Console.WriteLine("You will now exit the system ");
            ExitProgram(ref gil);

        }
    }
    if (slotGilRisk > gil)
    {
        System.Console.WriteLine("You do not have enough gil... sorry");
        IntroSlotMachine(ref gil);
    }
    }

}


static void SlotStartUp( ref int gil, ref int slotGilRisk)
{
    System.Console.WriteLine("You are now entering our\nSLOT MACHINE GAME!!! ");
    System.Console.WriteLine("In this game you will be asked if you would like to spin the wheel ");
    System.Console.WriteLine("If you get 3 matching words you will get...\nTRIPLE THE POINTS");
    System.Console.WriteLine("If you get 2 matching words you will get...\nDOUBLE the points");
    System.Console.WriteLine("If you get 0 matching words you will get...\n zero points :(");
    System.Console.WriteLine("If you would like to exit You may enter '2' but you will not get your points back :(");
    System.Console.WriteLine("enter 1 to continue");
    int slotStartConfirm = int.Parse(Console.ReadLine());
    
        if (slotStartConfirm == 1)
        {
            SlotMachineGame(ref gil, ref slotGilRisk); 
        }
        else if (slotStartConfirm == 2)
        {
            ExitProgram(ref gil);
        }
        else
        {
            System.Console.WriteLine("invalid");
            System.Console.WriteLine("enter 1");
            slotStartConfirm = int.Parse(Console.ReadLine());
            if (slotStartConfirm != 1)
            {
                ExitProgram(ref gil);
            }
            else if (slotStartConfirm == 1)
            {
                SlotMachineGame(ref gil, ref slotGilRisk); 
            }
        }
         
}

static void SlotMachineGame(ref int gil, ref int slotGilRisk)
{
 
  while(gil > 0 && gil < 300)
   { 
    Console.Clear();
    System.Console.WriteLine("ARE YOU READY TO SPIN THE WHEEL??? (YES OR NO) ");
    string wheelSpinConfirm = Console.ReadLine();

     if(wheelSpinConfirm.ToUpper() == "YES")
    {
        
        System.Console.WriteLine("wheel is spinning ");
        System.Console.WriteLine("...");

        Random rndm = new Random();
        string [] word = {"Elephant", "Computer", "Football", "Resume", "Crimson", "Capstone"}; 
        string wordOne = word[rndm.Next(6)];
        string wordTwo = word[rndm.Next(6)];
        string wordThree = word[rndm.Next(6)];
        
        System.Console.WriteLine(wordOne + " " + wordTwo + " " + wordThree);  

        if(wordOne == wordTwo && wordOne == wordThree )
        {
            System.Console.WriteLine("ALL THREE MATCH!!!!");
            System.Console.WriteLine("YOUR GIL RISKED WILL NOW BE TRIPLED!!!!");
            int winnings = slotGilRisk * 3;
            gil += winnings;
            System.Console.WriteLine($"You now have {gil} gil remaining");
            SlotPlayAgain(ref gil, ref slotGilRisk);

            
        }
        else if (wordOne == wordTwo || wordTwo == wordThree|| wordOne == wordThree )
        {
            System.Console.WriteLine("You got two to match\n Your gil risked will now be doubled");
            int winnings = slotGilRisk * 2;
            gil += winnings;
            System.Console.WriteLine($"You now have {gil} gil remaining"); 
            SlotPlayAgain(ref gil, ref slotGilRisk);
        }
        else if (wordOne != wordTwo && wordTwo != wordThree)
        {
            System.Console.WriteLine("None of those matched. You lost what you risked");
            gil -= slotGilRisk;
            System.Console.WriteLine($"You have {gil} gil remaining");
            SlotPlayAgain(ref gil, ref slotGilRisk);
            gil -= slotGilRisk;
        }
        
    }   
            
    if (gil <= 0)
    {
        System.Console.WriteLine("you have lost all of your gil");
        ExitProgram(ref gil);
    }
    else if (gil >= 300)
    {
        System.Console.WriteLine("You have enough gil for rent this month ");
    }
    
   }
}


static void SlotPlayAgain(ref int gil, ref int slotGilRisk) // allows user to play again
{
    int computerWins = 0;
    int userWins = 0;
    System.Console.WriteLine("Would you like to Play again? (Yes or No)");
    string playAgainAnswer = Console.ReadLine();

    if (playAgainAnswer.ToUpper() == "YES")
    {
        SlotMachineGame(ref gil, ref slotGilRisk);
    }
    else if (playAgainAnswer.ToUpper() == "NO")
    {
        StartUp(ref gil, ref computerWins, ref userWins);
    }
    else
    {
        System.Console.WriteLine("invalid");
        SlotPlayAgain(ref gil, ref slotGilRisk);
    }
 

}
//////////////////////////////////////////////////////////////////////////////////////////////Black Jack/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

static void BlackJackStartUp(ref int gil)
{
    System.Console.WriteLine("Welcome to our Black Jack Game");
    System.Console.WriteLine("In this game You will roll a dice as may times as you would like");
    System.Console.WriteLine("But be careful because each roll is totaled and if that total exceeds 21 you BUST and lose all the gil you risked to play");
    System.Console.WriteLine("You will play against a computer\nIf the computer total is greater than yours or a tie occurs\nThen the computer wins and you have to start over :( ");
    System.Console.WriteLine("If you win Your gil are doubled!");
    System.Console.WriteLine("If you would like to continue please enter 'yes' or 'no' ");
    string blackjackStartupConinued = Console.ReadLine();
    if (blackjackStartupConinued.ToLower() == "yes")
    {
        System.Console.WriteLine($"Gil Amount: {gil}");
        System.Console.WriteLine("GOOD LUCK");
        
        BlackJackGilRisk(ref gil);
    }

    else if (blackjackStartupConinued.ToLower() == "no")
    {
        ExitProgram(ref gil);
    }
    else
    {
        System.Console.WriteLine("invalid option\n You will be taken to the exit menu now");
        ExitProgram(ref gil);

    }
}


static void BlackJackGilRisk(ref int gil)
{
    System.Console.WriteLine("Enter the amount of gil you would like to risk");
    int blackjackGilRisk = int.Parse(Console.ReadLine());

    while (gil >= 0 || gil >= 300)
    {
        if(gil <= 0 )
        {
            System.Console.WriteLine("You do not have enough gil to play");
            ExitProgram(ref gil);
        }
        if (gil >= 300)
        {
            System.Console.WriteLine("Congrats!!! You have 300 or more gil which completes your goal");
            System.Console.WriteLine("You will now exit the program");
        }
            gil -= blackjackGilRisk;
            System.Console.WriteLine($"You risked {blackjackGilRisk} so you now have {gil}");
            
            if(blackjackGilRisk > 0 && blackjackGilRisk <= gil)
            {
                RollDice(ref gil, ref blackjackGilRisk);
            }
            
            else if(blackjackGilRisk < 0)
            {
                System.Console.WriteLine("You must wnter an amount greater than 0");
                BlackJackGilRisk(ref gil);
            }

    }
}

static void RollDice(ref int gil, ref int blackjackGilRisk)
{
    Random rndmDice = new Random();
    Random rndmDice2 = new Random();

    int roll1 = rndmDice.Next(9);
    int roll2 = rndmDice2.Next(9);
    
    System.Console.WriteLine($"You rolled a {roll1} on roll 1");
    System.Console.WriteLine($"You rolled a {roll2} on roll 2");
    if (roll1 == 0 )
    {
        roll1 = 1 * 10;
        
        
    }
    else if (roll2 == 0)
    {
        roll2 = 1 * 10;
    }

    int total = roll1 + roll2;
    BlackJack(ref total,ref roll1,ref roll2, ref gil, ref blackjackGilRisk );

}

static void BlackJack(ref int total, ref int roll1, ref int roll2, ref int gil, ref int blackjackGilRisk)
{
  
    System.Console.WriteLine($"the sum of your rolls are {total}");
    if (total == 21)
    {
        System.Console.WriteLine("BLACKJACK!!!!");
        gil += (blackjackGilRisk * 2);
        System.Console.WriteLine($"You now have: {gil} gil");
    }
    else if (total < 21)
    {    
        BlackJackRollAgain(ref total,ref roll1,ref roll2, ref gil, ref blackjackGilRisk );   
    }
    else if (total > 21)
    {
        System.Console.WriteLine("bust");

    }
     
}

//roll again 
static void BlackJackRollAgain(ref int total, ref int roll1, ref int roll2, ref int gil, ref int blackjackGilRisk) 
{
   
    System.Console.WriteLine("Would you like to roll again??  (yes or no)");// prime read
    string rollAgain = Console.ReadLine();
        if(rollAgain.ToLower() == "no")
        {  
        System.Console.WriteLine($"\nYou rolled a total of: {total}\n");
        System.Console.WriteLine("It is now the computers turn to roll");
        ComputerRandomDice(ref total, ref gil, ref blackjackGilRisk);
        }  
   

    while(rollAgain.ToLower() != "no" )// condition
    {
        
        Random rndmDice = new Random();
        int roll = rndmDice.Next(10);
        total += roll;
    
        System.Console.WriteLine($"you rolled a {roll}\nYour new total is now {total}");
        if (total == 21)
        {
            System.Console.WriteLine("BLACKJACK!!!!");
            System.Console.WriteLine("YOU WIN!!!!!");
            BlackJackPlayAgain(ref gil);
            
        }
            
        else if (total > 21)
        {
            System.Console.WriteLine("bust");
            System.Console.WriteLine("YOU LOSE!!!!!");
            BlackJackPlayAgain(ref gil);
            
        } 
          
        System.Console.WriteLine("Would you like to roll again??  (yes or no)"); // update read
        rollAgain = Console.ReadLine();   
        if(rollAgain.ToLower() == "no")
        {  
        System.Console.WriteLine($"\nYou rolled a total of: {total}");
        System.Console.WriteLine("It is now the computers turn to roll");
        ComputerRandomDice(ref total, ref gil, ref blackjackGilRisk);
        }  
      
    }  
       
}


static void BlackJackPlayAgain(ref int gil)
{

    System.Console.WriteLine("Would you like to play again??  (YES or NO)");
    string blackjackPlayAgain = Console.ReadLine();

    if  (blackjackPlayAgain.ToUpper() == "YES")
    {
        BlackJackGilRisk(ref gil);
       
    }
    else if (blackjackPlayAgain.ToUpper() == "NO")
    {
        ExitProgram(ref gil);
    }
    else
    {
        System.Console.WriteLine("invalid");
        BlackJackPlayAgain( ref gil);
    }

}
///////////////computer black jack options

static void ComputerBlackJack(ref int computerTotal, ref int total, ref int gil, ref int blackjackGilRisk)
{
    
    System.Console.WriteLine($"the sum of the computer's rolls are {computerTotal}");
    if (computerTotal == 21)
    {
        System.Console.WriteLine("BLACKJACK!!!!");
        
    }
    else if (computerTotal < 21)
    {
        
        ComputerBlackJackRollAgain(ref computerTotal, ref total, ref gil, ref blackjackGilRisk);

        
    }
    else if (computerTotal > 21)
    {
        System.Console.WriteLine("bust");
    }
      
}

static void ComputerRandomDice(ref int total, ref int gil, ref int blackjackGilRisk)
{
    
    Random rndmComDice = new Random();
    Random rndmComDice2 = new Random();

    int rolls1 = rndmComDice.Next(7,9);
    int rolls2 = rndmComDice2.Next(7,9);
    
    System.Console.WriteLine($"The computer rolled a {rolls1}");
    System.Console.WriteLine($"The computer rolled a {rolls2}");
    if (rolls1 == 0 )
    {
        rolls1 = 1 * 10;
        
        
    }
    else if (rolls2 == 0)
    {
        rolls2 = 1 * 10;
    }

    int computerTotal = rolls1 + rolls2;
    ComputerBlackJack(ref computerTotal,ref total, ref gil, ref blackjackGilRisk);
    
}

static void ComputerBlackJackRollAgain(ref int computerTotal, ref int total, ref int gil, ref int blackjackGilRisk)
{
    int computerWins = 0;
    int userWins = 0;
    System.Console.WriteLine("Would you(computer) like to roll again??  (yes or no)");
    string rollAgainComputer = Console.ReadLine();
    
    while(rollAgainComputer.ToLower() != "no" )
    {
        
        Random rndmDice = new Random();
        int roll = rndmDice.Next(10);
        computerTotal += roll;
    
        System.Console.WriteLine($"THE COMPUTER rolled a {roll}\nThe computers new total is now {computerTotal}");
        if (computerTotal == 21)
        {
            System.Console.WriteLine("BLACKJACK!!!!");
            System.Console.WriteLine("The computer won!");
            System.Console.WriteLine("Better luck next time");
            computerWins += 1;
            gil -= blackjackGilRisk;
            BlackJackPlayAgain(ref gil);
            
        }
            
        else if (computerTotal > 21)
        {
            System.Console.WriteLine("bust");
            System.Console.WriteLine("YOU WINN!!!!!");
            gil += (blackjackGilRisk * 2);
            userWins += 1;
            BlackJackPlayAgain(ref gil);
            
        } 
                 
        System.Console.WriteLine("Would you(computer) like to roll again??  (yes or no)"); // update read
        rollAgainComputer = Console.ReadLine();   
          
    }      

    if (rollAgainComputer.ToLower() == "no")
    {
        
        if (computerTotal < 21 )
        {
            System.Console.WriteLine($"\nThe computer rolled a total of: {computerTotal}");
            
            BlackJackWinner(ref computerTotal, ref total, ref gil, ref blackjackGilRisk, ref computerWins, ref userWins );
        }
               
    }  
            
}

///////END computer play
static void BlackJackWinner(ref int total, ref int computerTotal, ref int gil, ref int blackjackGilRisk, ref int computerWins, ref int userWins)
{
    
    System.Console.WriteLine("1. continue ");
    int userInput = int.Parse(Console.ReadLine());
    while (userInput == 1)
    {
        if (computerTotal < total)
        {
            System.Console.WriteLine("You lose this round ");
            System.Console.WriteLine($"You rolled {computerTotal} while the computer rolled {total}");
            computerWins += 1;
            gil -= blackjackGilRisk;
            ScoreBoard(ref gil, ref computerWins, ref userWins);
                  
        }
        else if (computerTotal > total)
        {
            System.Console.WriteLine($"The winner of this round is... {computerTotal} {total} ");
            System.Console.WriteLine($"YOU!!!\nYOU WON!!!!");
            gil += (blackjackGilRisk * 2);
            userWins += 1;
            ScoreBoard(ref gil, ref computerWins, ref userWins);
         
        }
        else if (total == computerTotal)
        {
            System.Console.WriteLine("this match was a tie");
            gil -= blackjackGilRisk;
            computerWins += 1; 
            ScoreBoard(ref gil, ref computerWins, ref userWins);
        }
      
    }
    BlackJackWinner(ref total, ref computerTotal, ref gil, ref blackjackGilRisk, ref computerWins, ref userWins);
    
}


////////////////////////////////////////////////////////////////////////////////////////////// Score Board //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
static void ScoreBoard(ref int gil, ref int computerWins, ref int userWins)
{
    
    System.Console.WriteLine($"Computer WINS: {computerWins}  User WINS: {userWins}");

    System.Console.WriteLine($"total gil: {gil}\n");
    System.Console.WriteLine("would you like to:\n1. return to menu\n2. exit ");
    int scoreboardReturnOption = int.Parse(Console.ReadLine());
    
        if (scoreboardReturnOption == 1)
        {
            StartUp(ref gil, ref computerWins, ref userWins);
        }
        else if (scoreboardReturnOption == 2)
        {
            ExitProgram(ref gil);
        }
        else
        {
            System.Console.WriteLine("invalid");
            System.Console.WriteLine("would you like to:\n1. return to menu\n2. exit ");
            scoreboardReturnOption = int.Parse(Console.ReadLine());
            if (scoreboardReturnOption == 1)
            {
                StartUp(ref gil, ref computerWins, ref userWins);
            }
            else if (scoreboardReturnOption == 2)
           {
                ExitProgram(ref gil);
           }
           else
           {
                ExitProgram(ref gil);
           }
            
        }
    
}


static void ExitProgram(ref int gil)
{
    int computerWins = 0;
    int userWins = 0;
    System.Console.WriteLine("Are you sure you would like to exit the program?  (YES or NO)");
    string exitGame = Console.ReadLine();
    

        if (exitGame.ToUpper() == "NO" && gil > 0)
        {
           StartUp(ref gil, ref computerWins, ref userWins);
        }
        else if (exitGame.ToUpper() == "NO" && gil < 0)
        {
            System.Console.WriteLine("You do not have enough gil to play\n you will now exit the system");
        }       
        if (exitGame.ToUpper() == "YES")
        {
            System.Console.WriteLine("Thank you for playing! Hope you had fun!\nBYE BYE");
        }
    
}