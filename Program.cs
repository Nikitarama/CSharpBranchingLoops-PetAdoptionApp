// - Since you're instantiating the array without initializing any values, you use the 'new' operator 
// (the new operator is used to create a new instance of a type). 
// - The number of rows is defined by maxPets, which has been initialized to eight.
// - Using a nullable string is best practice for capturing input from the ReadLine() method

// the ourAnimals array will store the following: 
using System.ComponentModel.DataAnnotations;
using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("en-US");

//This project is a "minimal viable product" (MVP) feature. 
//MVP features are intended to be a basic working prototype of a feature that enables quick and easy delivery. 
//An MVP isn't usually a final product, its purpose is to help you work through an idea, test it, and gather further requirements.

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];   //[the array limit name, amount of rows] 
//                                              // [,] to signify its a multidimensional string

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.00";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "tbd";
            animalPersonalityDescription = "tbd";
            animalNickname = "tbd";
            suggestedDonation = "0.00";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "0.00";
            break;
    }
    ;

    ourAnimals[i, 0] = "ID #: " + animalID;                          //this layout instead of just ourAnimals[i] cos its multidimensional
    ourAnimals[i, 1] = "Species: " + animalSpecies;                  //this is placed at the bottom cos it needs the data and its layout before putting it together for display
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;


    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

// display the top-level menu options

Console.Clear();                              //clears console display


do    //for loop needs condition to display, do loop just displays
{

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    // pause code execution
    readResult = Console.ReadLine();

    if (readResult != null)
    {
        menuSelection = readResult.ToLower();

    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                Console.WriteLine();
                if (ourAnimals[i, 0] != "ID #: ")         //if they don't have the default ID - so if the array field is not empty then display       
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                    //Console.WriteLine(ourAnimals[i, 0]);
                    // Console.WriteLine(ourAnimals[i, 1]);       //- my alternative (longer) way - however you can decide how you want the data to display 
                    // Console.WriteLine(ourAnimals[i, 3]);       //- the advantage of using the above method is that you can 
                    // Console.WriteLine(ourAnimals[i, 2]);       // just change the limit of animals displayed by the "<6"
                    // Console.WriteLine($"{ourAnimals[i, 5]}");
                    // Console.WriteLine($"{ourAnimals[i, 4]}");
                    // Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();

            // Console.Write($"These are all of our animals: {0}", ourAnimals[1, 4]);     //my mistake
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";                             //the "yes" option to add a pet
            int petCount = 0;                                   // the zero based counter that'll add to the array

            for (int i = 0; i < maxPets; i++)                 // loops and increments through array again until there is no ID
            {
                if (ourAnimals[i, 0] != "ID #: ")            //expression evaluates as "true" whenever the value assigned to petID, ourAnimals[i, 0], is NOT equal to the value listed on the right side of the equation
                {                                           //if the array item has no ID - add one to the petCount
                                                            //                                                         //increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                    Console.WriteLine("pet " + petCount + " in array\n");
                    petCount += 1;                       //adds a spot to the array.. 
                }
            }

            if (petCount < maxPets)                    // ..then sees if theres space to add info for another pet
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            // == checks value, = declares value
            while (anotherPet == "y" && petCount < maxPets)   // create two conditions that are true to perform the add
            {                                                // continues to iterate as long as anotherPet is equal to y and petCount is less than maxPets
                bool validEntry = false;
                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();

                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                            //animalSpecies is dog/cat, the subString which is indicating to the first letter d/c

                            // Console.WriteLine("\nID:" + animalID);
                            // Console.WriteLine("Species:" + animalSpecies + "\n");             //if you want the console to display the pet even if its not cat or dog
                            validEntry = false;                                                  // validEntry = true;
                        }
                        // else if (animalSpecies != null)                       //if you want the console to store the pet even if its not cat or dog
                        // {
                        //     animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                        //    Console.WriteLine("\nID:" + animalID);
                        //     validEntry = true;
                        // }
                        else
                        {
                            // animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                            // Console.WriteLine("\nID:" + animalID);
                            // Console.WriteLine("Species:" + animalSpecies + "\n");
                            validEntry = true;
                        }

                    }
                } while (validEntry == false);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry.
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();

                    if (readResult != null)     //if its null it loops to the top 
                    {
                        animalAge = readResult;
                        if (animalAge != "?")                    // to check whether the user entered ? before testing for a valid integer
                        {
                            validEntry = int.TryParse(animalAge, out petAge); // if its an int = True, if its a Str and not "?" it loops to the top
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");   //loops until there's an entry

                // displays the new pet info and what number in the array they are
                Console.WriteLine("\nNew pet that you've added:");
                Console.WriteLine("pet #" + petCount);
                Console.WriteLine("ID:" + animalID);
                Console.WriteLine("Species:" + animalSpecies);
                Console.WriteLine("Age:" + animalAge);
                Console.WriteLine("Physical description:" + animalPersonalityDescription);
                Console.WriteLine("Personality:" + animalPersonalityDescription);
                Console.WriteLine("Nickname:" + animalNickname + "\n");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                //adds to the pet count to update the # of pets
                petCount += 1;

                if (petCount < maxPets)
                {
                    Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                }

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do                                      //a do while so that when you press anything else it loops until you type "y" or "n"
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");

                }
            }
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete

            int newPetAge;
            petCount = 0;
            bool passed = int.TryParse(animalAge, out newPetAge);

            // two for loops for a two-dimensional array to target the specific value within the fields
            do
            {

                for (int i = 0; i < maxPets; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ourAnimals[i, j] == "ID #:")
                        {
                            passed = true;
                        }

                        if (ourAnimals[i, j] != "ID #:")
                        {
                            if (ourAnimals[i, j] == "Age: ?")
                            {
                                Console.WriteLine("Enter an age for " + ourAnimals[i, 0]);
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    animalAge = readResult;

                                    if ((int.TryParse(animalAge, out newPetAge)))
                                    {
                                        if (animalAge != "0")
                                        {
                                            ourAnimals[i, 2] = "Age: " + newPetAge;
                                            Console.WriteLine(ourAnimals[i, j]);
                                            passed = true;
                                        }
                                        else
                                        {
                                            passed = false;
                                        }
                                    }
                                    else if (!(int.TryParse(animalAge, out newPetAge)))
                                    {
                                        passed = false;
                                    }
                                }
                            }
                        }
                    }
                }
            } while (!passed);

            do
            {
                for (int i = 0; i < maxPets; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ourAnimals[i, j] == "ID #:")
                        {
                            continue;
                        }

                        if (ourAnimals[i, j] != "ID #:")
                        {
                            if (ourAnimals[i, j] == "Physical description: tbd")
                            {
                                Console.WriteLine("Enter a physical description for " + ourAnimals[i, 0] + " (size, color, gender, weight, housebroken)");
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    animalPhysicalDescription = readResult;

                                    if (animalPhysicalDescription != "")
                                    {
                                        ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                                        Console.WriteLine(ourAnimals[i, j]);
                                        Console.WriteLine();
                                        Console.WriteLine("Age and physical description fields are complete for all of our friends.");
                                        Console.WriteLine("Press the Enter key to continue");
                                    }
                                }

                            }
                        }
                    }
                }
            } while (animalPhysicalDescription == "");

            Console.ReadLine();

            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            do
            {
                for (int i = 0; i < maxPets; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ourAnimals[i, j] == "ID #:")
                        {
                            continue;
                        }

                        if (ourAnimals[i, j] != "ID #:")
                        {
                            if (ourAnimals[i, j] == "Nickname: tbd")
                            {
                                Console.WriteLine("Enter a nickname for " + ourAnimals[i, 0]);
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    animalNickname = readResult;

                                    if (animalNickname != "")
                                    {
                                        ourAnimals[i, 3] = "Nickname:" + animalNickname;
                                        Console.WriteLine(ourAnimals[i, j]);
                                        Console.WriteLine();
                                    }
                                }

                            }
                        }
                    }
                }
            } while (animalNickname == "");

            do
            {
                for (int i = 0; i < maxPets; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (ourAnimals[i, j] == "ID #:")
                        {
                            continue;
                        }

                        if (ourAnimals[i, j] != "ID #:")
                        {
                            if (ourAnimals[i, j] == "Personality: tbd")
                            {
                                Console.WriteLine("Enter a personality description for " + ourAnimals[i, 0] + " (likes or dislikes, tricks, energy level)");
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    animalPersonalityDescription = readResult;

                                    if (animalPersonalityDescription != "")
                                    {
                                        ourAnimals[i, 5] = "Personality description: " + animalPersonalityDescription;
                                        Console.WriteLine(ourAnimals[i, j]);
                                        Console.WriteLine();
                                        Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
                                        Console.WriteLine("Press the Enter key to continue");
                                        readResult = Console.ReadLine();
                                    }
                                }

                            }
                        }
                    }
                }
            } while (animalPersonalityDescription == "");

            break;

        case "5":
            // Edit an animal's age

            for (int i = 0; i < maxPets; i++)
            {
                Console.WriteLine();
                if (ourAnimals[i, 0] != "ID #: ")   //not default with an ID      
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }

            Console.WriteLine("Which animal's age would you like to edit? Provide the ID:");
            readResult = Console.ReadLine();
            do
            {

                if (readResult != null)
                {
                    animalID = readResult.ToLower().Trim();

                    if (animalID != "")
                    {
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 0].Contains(animalID))
                            {
                                Console.WriteLine($"This is {ourAnimals[i, 0]}'s {ourAnimals[i, 2]}");
                                Console.WriteLine();

                                Console.WriteLine("Enter the new age for " + ourAnimals[i, 0]);
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    animalAge = readResult;

                                    if ((int.TryParse(animalAge, out newPetAge)))
                                    {
                                        if (animalAge != "0")
                                        {
                                            ourAnimals[i, 2] = "Age: " + newPetAge;
                                            Console.WriteLine();
                                            Console.WriteLine($"{ourAnimals[i, 0]}'s new {ourAnimals[i, 2]}");
                                            Console.WriteLine();
                                            Console.WriteLine("The age field has been updated.");
                                            Console.WriteLine("Press the Enter key to continue");
                                            readResult = Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid entry. Age cannot be zero. Please try again.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid entry. Age must be a number. Please try again.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry. ID cannot be blank. Please try again.");
                        readResult = false.ToString(); // to break out of the loop and go back to the menu
                    }
                }

            } while (readResult == "");


            break;

        case "6":
            //Edit an animal’s personality description
            bool pass = false;

            for (int i = 0; i < maxPets; i++)
            {
                Console.WriteLine();
                if (ourAnimals[i, 0] != "ID #: ")   //not default with an ID      
                {
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }


            Console.WriteLine("Which animal's personality description would you like to edit? Provide the ID:");
            readResult = Console.ReadLine();
            do
            {

                if (readResult != null)
                {
                    animalID = readResult.ToLower().Trim();

                    if (animalID != "")
                    {
                        for (int i = 0; i < maxPets; i++)
                        {

                            if (ourAnimals[i, 0].Contains(animalID))
                            {
                                Console.WriteLine($"This is {ourAnimals[i, 0]}'s {ourAnimals[i, 5]}");
                                Console.WriteLine();

                                Console.WriteLine("Enter the new personality description for " + ourAnimals[i, 0] + " (likes or dislikes, tricks, energy level)");
                                readResult = Console.ReadLine();

                                if (readResult != null)
                                {
                                    animalPersonalityDescription = readResult;

                                    if (animalPersonalityDescription != "")
                                    {
                                        ourAnimals[i, 5] = "Personality description is now: " + animalPersonalityDescription;
                                        Console.WriteLine();
                                        Console.WriteLine($"{ourAnimals[i, 0]}'s new {ourAnimals[i, 5]}");
                                        Console.WriteLine();
                                        Console.WriteLine("The personality description field has been updated.");
                                        Console.WriteLine("Press the Enter key to continue");
                                        readResult = Console.ReadLine();
                                        readResult = false.ToString(); // to break out of the loop and go back to the menu
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid entry. Personality description cannot be blank. Please try again.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid entry. Personality description cannot be blank. Please try again.");
                                }

                            }
                   
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid entry. ID cannot be blank. Please try again.");
                        pass = true; // to break out of the loop and go back to the menu
                    }
                }

            } while (pass == true); // to break out of the loop and go back to the menu if the entry is invalid (blank)

            break;

        case "7":
            //Display all cats with a specified characteristic
            string catCharacteristic = "";

            while (catCharacteristic == "")
            {
                // have the user enter physical characteristics to search for
                Console.WriteLine($"\nEnter one desired cat characteristics to search for");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    catCharacteristic = readResult.ToLower().Trim();
                }
            }
            string catDescription = "";
            bool noMatchesCat = true;

            // #6 loop through the ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("cat"))
                {
                    // #7 Search combined descriptions and report results
                    catDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    if (catDescription.Contains(catCharacteristic))
                    {
                        Console.WriteLine($"\nOur cat {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine(catDescription);

                        noMatchesCat = false;
                    }
                }
            }
            if (noMatchesCat)
            {
                Console.WriteLine("None of our cats are a match found for: " + catCharacteristic);
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                // have the user enter physical characteristics to search for
                Console.WriteLine($"\nEnter one desired dog characteristics to search for");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                }
            }
            string dogDescription = "";
            bool noMatchesDog = true;

            // #6 loop through the ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    // #7 Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    if (dogDescription.Contains(dogCharacteristic))
                    {
                        Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine(dogDescription);

                        noMatchesDog = false;
                    }
                }
            }
            if (noMatchesDog)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// -The reason why you don't use a foreach loop in this situation is because the ourAnimals array is multidimensional array. 
// -Since ourAnimals is a multidimensional string array, each element contained within ourAnimals is a separate item of type string. 
// -If you used a foreach loop to iterate through ourAnimals, the foreach would recognize each string as a separate item in a list of 48 string items (8 x 6 = 48). 
// -The foreach statement wouldn't process the two array dimensions separately. In other words, a foreach loop won't recognize 8 rows of string elements, where each
// row contains a column of 6 items. Since you want to work with one animal at a time, and process all six animal characteristics during a single iteration, a foreach 
// statement isn't the right choice.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//The reason why you don't use a foreach loop in this situation is because the ourAnimals array is multidimensional array. Since ourAnimals is a multidimensional string array,
// each element contained within ourAnimals is a separate item of type string. If you used a foreach loop to iterate through ourAnimals, the foreach would recognize each string as a
// separate item in a list of 48 string items (8 x 6 = 48). The foreach statement wouldn't process the two array dimensions separately. In other words, a foreach loop won't recognize
// 8 rows of string elements, where each row contains a column of 6 items. Since you want to work with one animal at a time, and process all six animal characteristics during a single 
//iteration, a foreach statement isn't the right choice.

// string[][] jaggedArray = new string[][]
// {
//     new string[] { "one1", "two1", "three1", "four1", "five1", "six1" },
//     new string[] { "one2", "two2", "three2", "four2", "five2", "six2" },
//     new string[] { "one3", "two3", "three3", "four3", "five3", "six3" },
//     new string[] { "one4", "two4", "three4", "four4", "five4", "six4" },
//     new string[] { "one5", "two5", "three5", "four5", "five5", "six5" },
//     new string[] { "one6", "two6", "three6", "four6", "five6", "six6" },
//     new string[] { "one7", "two7", "three7", "four7", "five7", "six7" },
//     new string[] { "one8", "two8", "three8", "four8", "five8", "six8" }
// };

// foreach (string[] array in jaggedArray)
// {
//     foreach (string value in array)
//     {
//         Console.WriteLine(value);
//     }
//     Console.WriteLine();
// }
//----------------------------------------------------------------------------------
