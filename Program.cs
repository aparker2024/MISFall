   using oop_lab_aparker2024;         
            
            //Variable to accept user input
            int station;

            //Declare and instatiate a television object            
            Television bigScreen = new Television("Toshiba", 55);

            

            //Turn the power on
            bigScreen.Power();

            //Display the state of the television
            Console.WriteLine(bigScreen.ToString());

            //Prompt the user for input and store it in the station variable
            Console.WriteLine("What channel do you want? ");
            station = int.Parse(Console.ReadLine());

            //Change the channel on the television
            bigScreen.SetChannel(station);

            //Increase the volumne of the television
            bigScreen.IncreaseVolume();

            //Display the current channel and volumne
            Console.WriteLine("Channel: " + bigScreen.GetChannel() + " Volume: " + bigScreen.GetVolume());

            Console.WriteLine("Too loud!  Lowering the volume.");

            //Decrease the volume
            for (int x = 0; x < 6; x++)
            {
                bigScreen.DecreaseVolume();
            }

            //Display the current channel and volumne
            Console.WriteLine("Channel: " + bigScreen.GetChannel() + " Volume: " + bigScreen.GetVolume());

            //create blank line
            Console.WriteLine();

            //HERE IS WHERE YOU DO TASK 5
            Television portable = new Television("Sony", 19);
            portable.Power();
            Console.WriteLine(portable.ToString());
            Console.WriteLine("What channel do you want? ");
            station = int.Parse(Console.ReadLine());
            portable.SetChannel(station);

            for (int x = 0; x < 2; x++)
            {
                portable.DecreaseVolume();
                
                
            }

            Console.WriteLine("Channel: " + portable.GetChannel() + " Volume: " + portable.GetVolume());

            Console.ReadKey();