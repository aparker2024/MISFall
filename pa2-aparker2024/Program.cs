
        
StartUpMenu();


    
static void Menu()
{
    DisplayMenu(); // calling display menu method

    int userNum = GetMenuChoice(); // priming read

    while(userNum != 3) // condition check  //for menu option 1. budget start up 2. currency converter 3. exits
    {
        if (userNum == 1)
        {
            BudgetStartUp(); 
          
            
          
        }
       else if (userNum == 2)
        {
            CurrencyConverter();
            
        }

        

    }
}
static void StartUpMenu()
{
    Console.Clear();
    System.Console.WriteLine("WELCOME!!!!");
    System.Console.WriteLine("Thank you for choosing our App!!!");
    System.Console.WriteLine("Select 1 to continue");
   int userInput = int.Parse(Console.ReadLine());

   if (userInput == 1)
   {
       

       Menu(); 
   }
  
    if (userInput != 1) // error handling
    {
        System.Console.WriteLine("invalid option, please enter 1");
        userInput = int.Parse(Console.ReadLine());
        if(userInput == 1)
        {
            Console.Clear();
            Menu();
        }
        else
        {
            System.Console.WriteLine("INVALID OPTION.... BYE BYE");
        }
    }
   
   
    
    }


static void DisplayMenu()
{
    System.Console.WriteLine("1: Budget Calculator ");
    System.Console.WriteLine("2: Currency Converter ");
    System.Console.WriteLine("3: Exit");
}

static int GetMenuChoice()
{
    int menuChoice = int.Parse(Console.ReadLine());

    while (menuChoice < 1 || menuChoice > 3 ) // error handling
    {
        System.Console.WriteLine("Invalid Menu Choice");
        System.Console.WriteLine("Enter A valid option");
        Menu();
        menuChoice = int.Parse(Console.ReadLine());
    }
    return menuChoice;
}
static void BudgetStartUp()
{
Console.Clear();
System.Console.WriteLine("Welcome to our Budget Calculator!!!");
System.Console.WriteLine("please enter 1 to continue");
int userInput = int.Parse(Console.ReadLine());
if (userInput == 1)
{
    Console.Clear();
    BudgetCalculator();
}
else // error handling
{
    System.Console.WriteLine("invalid");
    BudgetStartUp();
}


}


static void BudgetCalculator()
{
double monthlySavings = 0.0;
System.Console.WriteLine("Please enter overall monthly income");
int monthlyIncome = int.Parse(Console.ReadLine());


System.Console.WriteLine($"You should take about {Math.Round(Savings (monthlyIncome, ref monthlySavings))} for Savings");
System.Console.WriteLine($"You should take about {Math.Round(Housing(monthlyIncome))} for Housing expenses");
System.Console.WriteLine($"You should take about {Math.Round(Food(monthlyIncome))} for Food expenses");
System.Console.WriteLine($"You should take about {Math.Round(Transportation(monthlyIncome))} for Transportation expenses");
System.Console.WriteLine($"You should take about {Math.Round(Entertainment(monthlyIncome))} for each eligible Family member for Entertainemnt/Personal expenses");
System.Console.WriteLine($"You should take about {Math.Round(Utilities(monthlyIncome))} for Utility expenses");
System.Console.WriteLine($"You should take about {Math.Round(Clothing(monthlyIncome))} for Clothing expenses");

System.Console.WriteLine("Enter 1 to continue");
int userInput = int.Parse(Console.ReadLine());
while(userInput == 1)
{

    AmountSpent(monthlyIncome, ref monthlySavings);

}
}
// should it sub the amounts each time through
static double Savings (int monthlyIncome, ref double monthlySavings)
{
    
    monthlySavings = monthlyIncome * .20;

    return monthlySavings;

}

static double Housing(int monthlyIncome)
{
    double  monthlyHousing = 0.0;
   monthlyHousing = monthlyIncome * .25;
   return monthlyHousing;
}

static double Food(int monthlyIncome)
{
    double  monthlyFood = 0.0;
   monthlyFood = monthlyIncome * .16;
   return monthlyFood;
}

static double Transportation (int monthlyIncome)
{
  double monthlyTransportation = 0.0;
  monthlyTransportation = monthlyIncome * .15;
  return monthlyTransportation;
}

static double Entertainment (int monthlyIncome)
{
  System.Console.WriteLine("Please enter the number of spending eligible family Members"); // ask user for amount of family members
  double eligibleFamilyMembers = double.Parse(Console.ReadLine());

  double monthlyPersonalBudget= 0.0;
  monthlyPersonalBudget = monthlyIncome * .25;
  return monthlyPersonalBudget / eligibleFamilyMembers;
}
static double Utilities (int monthlyIncome)
{
  double monthlyUtilities= 0.0;
  monthlyUtilities = monthlyIncome * .11;
  return monthlyUtilities;
}
static double Clothing (int monthlyIncome)
{
  double monthlyClothing= 0.0;
  monthlyClothing = monthlyIncome * .08;
  return monthlyClothing;
}

static void AmountSpent(int monthlyIncome, ref double monthlySavings)  // extra
{
   Console.Clear();
   System.Console.WriteLine("We are now going to calculate how much you should spend compared to what you did");
   System.Console.WriteLine("Enter 1 to continue");
  
   int userInput = int.Parse(Console.ReadLine());
   if (userInput == 1)
   {
    AmountSaved(monthlyIncome, ref monthlySavings);
   
   }
   else
   {
    System.Console.WriteLine("invalid option");
    AmountSpent(monthlyIncome, ref monthlySavings);
   }
   
}

static void AmountSaved(int monthlyIncome, ref double monthlySavings)
{
    System.Console.WriteLine("Enter the amount you saved");
    int userIn = int.Parse(Console.ReadLine());
    
   
    
    if( monthlySavings > userIn)
    {
        System.Console.WriteLine($"You should have saved about {monthlySavings - userIn} more this month");
        HousingExpensed(monthlyIncome, ref monthlySavings);
    }
    else if(monthlySavings == userIn)
    {
        System.Console.WriteLine($"That is a good amount to save");
        HousingExpensed(monthlyIncome, ref monthlySavings);

    }
     else if( monthlySavings < userIn)
    {
        System.Console.WriteLine($"You saved {userIn - monthlySavings }, which is fine but a little over what you should");
        HousingExpensed(monthlyIncome, ref monthlySavings);
    }
    
}

static void HousingExpensed(int monthlyIncome, ref double monthlyHousing)
{
    monthlyHousing = monthlyIncome * .25;
System.Console.WriteLine("Enter the amount you spent on housing this month");
int userInput = int.Parse(Console.ReadLine());


    if ( monthlyHousing > userInput)
    {
     System.Console.WriteLine($"You should have taken out about ${monthlyHousing - userInput} more this month "); 
       FoodExpensed(monthlyIncome, ref monthlyHousing);
    }
    else if (userInput == monthlyHousing)
    {
        System.Console.WriteLine($"You have took out a good amount for housing this month");
        FoodExpensed(monthlyIncome, ref monthlyHousing);
    }
    else if (monthlyHousing < userInput)
    {
    System.Console.WriteLine($"You took out ${userInput - monthlyHousing} over what you possibly should have");
        FoodExpensed(monthlyIncome, ref monthlyHousing);
    }

}

static void FoodExpensed(int monthlyIncome, ref double monthlyFood)
{
    monthlyFood = monthlyIncome * .16;
System.Console.WriteLine("Enter the amount you spent on Food this month");
int userInput = int.Parse(Console.ReadLine());


    if (userInput > monthlyFood)
    {
       System.Console.WriteLine($"You took out ${userInput - monthlyFood} over what you possibly should have");
       TransportationExpensed(monthlyIncome, ref monthlyFood);
    }
    else if (userInput == monthlyFood)
    {
        System.Console.WriteLine($"You have took out a good amount for Food this month");
        TransportationExpensed(monthlyIncome, ref monthlyFood);
    }
    else if (userInput < monthlyFood)
    {
        System.Console.WriteLine($"You should have taken out about ${monthlyFood - userInput} more for food this month"); 
        TransportationExpensed(monthlyIncome, ref monthlyFood);
    }

}

static void TransportationExpensed(int monthlyIncome, ref double monthlyTransportation)
{
    monthlyTransportation = monthlyIncome * .15;
System.Console.WriteLine("Enter the amount you spent on Transportation this month");
int userInput = int.Parse(Console.ReadLine());


    if (userInput > monthlyTransportation)
    {
       System.Console.WriteLine($"You took out ${userInput - monthlyTransportation} over what you possibly should have");
       EntertainmentExpensed(monthlyIncome, ref monthlyTransportation);
    }
    else if (userInput == monthlyTransportation)
    {
        System.Console.WriteLine($"You have took out a good amount for Transportation this month");
        EntertainmentExpensed(monthlyIncome, ref monthlyTransportation);
    }
    else if (userInput < monthlyTransportation)
    {
        System.Console.WriteLine($"You should have taken out about ${monthlyTransportation - userInput} more for transportation this month"); 
       EntertainmentExpensed(monthlyIncome, ref monthlyTransportation);
    }

}

static void EntertainmentExpensed(int monthlyIncome, ref double  monthlyPersonalBudget)
{
    monthlyPersonalBudget = monthlyIncome * .25;
System.Console.WriteLine("Enter the amount you spent on entertainment this month");
int userInput = int.Parse(Console.ReadLine());


    if (userInput > monthlyPersonalBudget)
    {
       System.Console.WriteLine($"You took out ${userInput - monthlyPersonalBudget} over what you possibly should have");
       UtilitiesExpensed(monthlyIncome, ref monthlyPersonalBudget);
    }
    else if (userInput == monthlyPersonalBudget)
    {
        System.Console.WriteLine($"You have took out a good amount for Entertainment this month");
        UtilitiesExpensed(monthlyIncome, ref monthlyPersonalBudget);
    }
    else if (userInput < monthlyPersonalBudget)
    {
        System.Console.WriteLine($"You should have taken out about ${monthlyPersonalBudget - userInput} more for Entertainment this month"); 
        UtilitiesExpensed(monthlyIncome, ref monthlyPersonalBudget);
    }

}
static void UtilitiesExpensed(int monthlyIncome, ref double  monthlyUtilities)
{

monthlyUtilities = monthlyIncome * .11;
System.Console.WriteLine("Enter the amount you spent on Utilities this month");
int userInput = int.Parse(Console.ReadLine());


    if (userInput > monthlyUtilities)
    {
       System.Console.WriteLine($"You took out ${userInput - monthlyUtilities} over what you possibly should have");
       ClothingExpensed(monthlyIncome, ref monthlyUtilities);
    }
    else if (userInput == monthlyUtilities)
    {
        System.Console.WriteLine($"You have took out a good amount for Utilties this month");
       ClothingExpensed(monthlyIncome, ref monthlyUtilities);
    }
    else if (userInput < monthlyUtilities)
    {
        System.Console.WriteLine($"You should have taken out about ${monthlyUtilities - userInput} more for utilities this month"); 
        ClothingExpensed(monthlyIncome, ref monthlyUtilities);
    }

}

static void ClothingExpensed(int monthlyIncome, ref double  monthlyClothing)
{
    
monthlyClothing = monthlyIncome * .08;
System.Console.WriteLine("Enter the amount you spent on Clothing this month");
int userInput = int.Parse(Console.ReadLine());



    if (userInput > monthlyClothing)
    {
       System.Console.WriteLine($"You took out ${userInput - monthlyClothing} over what you possibly should have");
       ExitBC();
    }
    else if (userInput == monthlyClothing)
    {
        System.Console.WriteLine($"You have took out a good amount for Clothing this month");
        ExitBC();
    }
    else if (userInput < monthlyClothing)
    {
        System.Console.WriteLine($"You should have taken out about ${monthlyClothing - userInput} more for clothing this month"); 
        ExitBC();
    }
   
}

static void ExitBC() //extra
{
   
    System.Console.WriteLine("Thank you for using our Budget Calculator");
    System.Console.WriteLine("Would you like to Exit or Return to the Menu ");
    System.Console.WriteLine("1. Menu");
    System.Console.WriteLine("2. Exit");
     int userInp = int.Parse(Console.ReadLine());

while (userInp != 3)
{
if (userInp == 1)
{
    Menu();
}
else if (userInp == 2)
{
    System.Console.WriteLine("bye bye");
}

else
{
    System.Console.WriteLine("invalid option");
    ExitBC();
}
}

}





static void CurrencyConverter()
{
   
    System.Console.WriteLine("Welcome to our Currency Converter");
   
    System.Console.WriteLine("1. Would you like to convert From US dollar to another currency ");
    System.Console.WriteLine("2. Would you like to convert From another currency to US dollar ");
    int userInput = int.Parse(Console.ReadLine());

    if (userInput == 1)
    {
        
        FromUStoFC();
    }
    else if(userInput == 2)
    {
        FromFCtoUS();
    }
    

}

static void FromUStoFC()
{
Console.Clear();
System.Console.WriteLine("Enter Which currency you would like to convert");
System.Console.WriteLine("1. British pound \n2. Swiss Franc\n3. Indian Rupee\n4.Canadian Dollar\n5. To Exit ");
int userInput = int.Parse(Console.ReadLine());

while (userInput != 5)
{
    
if (userInput == 1)
{
    BritishPound();
}
else if (userInput == 2)
{
    SwissFranc();
}
else if (userInput == 3)
{
    IndianRupee();
}
else if(userInput == 4)
{
    CanadianDollar();
}
}
}


static void BritishPound()
{
    double britishPound = 0.863;

System.Console.WriteLine("input amount you want converted");
int convertAmount = int.Parse(Console.ReadLine());

britishPound *= convertAmount;
System.Console.WriteLine($"That would be about {britishPound} in British Pounds");

}

static void SwissFranc()
{
double swissFranc = 0.980;

System.Console.WriteLine("Enter the amount you would like converted");
int convertAmount = int.Parse(Console.ReadLine());

swissFranc *= convertAmount;
System.Console.WriteLine($"That would be about {swissFranc} in Swish Franc");

}

static void IndianRupee()
{
    double indianRupee = 79.580;

System.Console.WriteLine("Enter the amount you would like converted");
int convertAmount = int.Parse(Console.ReadLine());

indianRupee *= convertAmount;
System.Console.WriteLine($"That would be about {indianRupee} in Indian rupee");

}

static void CanadianDollar()
{
double canadianDollar = 1.1315;

System.Console.WriteLine("Enter the amount you would like converted");
int convertAmount = int.Parse(Console.ReadLine());

canadianDollar *= convertAmount;
System.Console.WriteLine($"That would be about {canadianDollar} in Canadian dollars ");

}

static void FromFCtoUS()
{

Console.Clear();
System.Console.WriteLine("Enter Which currency you would like to convert to US dollars");
System.Console.WriteLine("1. British pound \n2. Swiss Franc\n3. Indian Rupee\n4.Canadian Dollar\n5. To Exit ");
int userInput = int.Parse(Console.ReadLine());

while (userInput != 5)
{
    
if (userInput == 1)
{
    BritishtoUS();

    System.Console.WriteLine("Would you like another amount converted?\n1. YES\n2. NO"); // extra

    int yesOrNo = int.Parse(Console.ReadLine());

    if (yesOrNo == 1)
    {
        FromFCtoUS();
    }
    else if (yesOrNo == 2)
    {
        Menu();
    }

}
else if (userInput == 2)
{
    SwissFranctoUS();

    
    System.Console.WriteLine("Would you like another amount converted?\n1. YES\n2. NO");

    int yesOrNo = int.Parse(Console.ReadLine());

    if (yesOrNo == 1)
    {
        FromFCtoUS();
    }
    else if (yesOrNo == 2)
    {
        Menu();
    }
}
else if (userInput == 3)
{
    IndianRupeetoUS();

    
    System.Console.WriteLine("Would you like another amount converted?\n1. YES\n2. NO");

    int yesOrNo = int.Parse(Console.ReadLine());

    if (yesOrNo == 1)
    {
        FromFCtoUS();
    }
    else if (yesOrNo == 2)
    {
        Menu();
    }
}
else if(userInput == 4)
{
    CanadianDollartoUS();

    
    System.Console.WriteLine("Would you like another amount converted?\n1. YES\n2. NO");

    int yesOrNo = int.Parse(Console.ReadLine());

    if (yesOrNo == 1)
    {
        FromFCtoUS();
    }
    else if (yesOrNo == 2)
    {
        Menu();
    }
}
}
}

static void BritishtoUS()
{
    double britishPound = .863;

    System.Console.WriteLine("Enter the amount you would like converted");
    int convertAmount = int.Parse(Console.ReadLine());

    britishPound = convertAmount/britishPound;
    System.Console.WriteLine($"That would be {britishPound} in US dollars");


}

static void SwissFranctoUS()
{
    double swissFranc = 0.980;

    System.Console.WriteLine("Enter the amount you would like converted");
    int convertAmount = int.Parse(Console.ReadLine());

    swissFranc = convertAmount/swissFranc;
    System.Console.WriteLine($"That would be {swissFranc} in US dollars");


}


static void IndianRupeetoUS()
{
    double indianRupee = 79.580;

    System.Console.WriteLine("Enter the amount you would like converted");
    int convertAmount = int.Parse(Console.ReadLine());

    indianRupee = convertAmount/indianRupee;
    System.Console.WriteLine($"That would be {indianRupee} in US dollars");

}

static void CanadianDollartoUS()
{
    double canadianDollar = 1.1315;

    System.Console.WriteLine("Enter the amount you would like converted");
    int convertAmount = int.Parse(Console.ReadLine());

    canadianDollar = convertAmount/canadianDollar;
    System.Console.WriteLine($"That would be {canadianDollar} in US dollars");

}





