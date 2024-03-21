string? playerChoice = "";
string? playerMove = "";
string? chooseName = "";
string playerName = "";
int playerHealth = 3;
int aiHealth = 3;
int highScore = 0;

Console.Clear();

Console.WriteLine("Welcome to Janken Game!");
Console.WriteLine("Do you want to play? \"Y/n\"");
playerChoice = Console.ReadLine();

if (playerChoice != null)
{
    bool startGame = false;

    if (playerChoice == "" || playerChoice.ToLower() == "y")
    {
        startGame = true;
    }

    Console.Write("Enter your name: ");
    chooseName = Console.ReadLine();

    if (chooseName != null)
    {
        if (chooseName != "")
            playerName = chooseName;

    }

    while (startGame == true)
    {
        while (playerHealth > 0 && aiHealth > 0 && startGame == true)
        {
            Console.Clear();
            Console.WriteLine($"High Score: {highScore}\n\n");
            Console.WriteLine($"{(playerName != "" ? $"{playerName}'s" : "Player's")} Health: {playerHealth}");
            Console.WriteLine($"AI's Health: {aiHealth}");
            Console.WriteLine("Choose your move: (a) Rock (b) Paper (c) Scissors");
            Console.WriteLine("Type (x) to quit the game.");
            playerMove = Console.ReadLine();

            if (playerMove != null)
            {
                if (playerMove.ToLower().Trim() == "x")
                {
                    startGame = false;
                    continue;
                }

                if (playerMove != "")
                {
                    if ((playerMove.ToLower() == "a") || (playerMove.ToLower() == "b") || (playerMove.ToLower() == "c"))
                    {
                        Random ai = new();
                        int aiMove = ai.Next(1, 4);
                        string aiMoveName;
                        string playerMoveName;
                        bool playerWin = false;

                        switch (aiMove)
                        {
                            case 1:
                                aiMoveName = "Rock";
                                break;
                            case 2:
                                aiMoveName = "Paper";
                                break;
                            case 3:
                                aiMoveName = "Scissors";
                                break;
                            default:
                                aiMoveName = "N/A";
                                break;
                        }

                        switch (playerMove)
                        {
                            case "a":
                                playerMoveName = "Rock";
                                break;
                            case "b":
                                playerMoveName = "Paper";
                                break;
                            case "c":
                                playerMoveName = "Scissors";
                                break;
                            default:
                                playerMoveName = "N/A";
                                break;
                        }

                        if (playerMoveName == aiMoveName)
                        {
                            Console.Clear();
                            Console.WriteLine($"{(playerName != "" ? $"{playerName}'s" : "Player")} chose {playerMoveName}");
                            Console.WriteLine($"AI chose {aiMoveName}");
                            Console.WriteLine($"\nDraw round.\n");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadLine();
                            continue;
                        }

                        if (
                            (playerMoveName == "Rock" && aiMoveName == "Scissors") ||
                            (playerMoveName == "Paper" && aiMoveName == "Rock") ||
                            (playerMoveName == "Scissors" && aiMoveName == "Paper")
                            )
                        {
                            playerWin = true;
                            aiHealth -= 1;
                        }
                        else
                        {
                            playerWin = false;
                            playerHealth -= 1;
                        }

                        Console.Clear();
                        Console.WriteLine($"{(playerName != "" ? $"{playerName}'s" : "Player")} chose {playerMoveName}");
                        Console.WriteLine($"AI chose {aiMoveName}");
                        Console.WriteLine($"\n{(playerWin == true ? (playerName != "" ? $"{playerName}" : "Player") : "AI")} won this round.\n");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();

                        if (playerHealth <= 0 || aiHealth <= 0)
                        {
                            if(playerHealth > aiHealth)
                                highScore += 1;

                            Console.Clear();
                            Console.WriteLine($"High Score: {highScore}\n\n");
                            Console.WriteLine($"{(playerName != "" ? $"{playerName}'s" : "Player's")} Health: {playerHealth}");
                            Console.WriteLine($"AI's Health: {aiHealth}");
                            Console.WriteLine("Choose your move: (a) Rock (b) Paper (c) Scissors");
                            Console.WriteLine("Type (x) to quit the game.");
                            Console.WriteLine($"\n\n{(playerHealth > aiHealth ? (playerName != "" ? $"{playerName}" : "Player") : "AI")} Wins!");
                            startGame = false;
                            playerMove = Console.ReadLine();

                            if (playerMove != null)
                            {
                                if (playerMove == "x")
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            if (startGame == false)
            {
                bool replay = false;

                while(replay == false)
                {
                    Console.Clear();
                    Console.WriteLine("Do you want to play again? \"Y/n\"");
                    playerChoice = Console.ReadLine();

                    if (playerChoice != null)
                    {
                        if (playerChoice == "" || playerChoice.ToLower() == "y")
                        {
                            playerHealth = 3;
                            aiHealth = 3;
                            replay = true;
                            startGame = true;
                        }
                        else if (playerChoice.ToLower() == "n" || playerChoice.ToLower() == "x")
                        {
                            startGame = false;
                            replay = true;
                            continue;
                        }
                        else
                            replay = false;
                    }

                }

            }

        }

    }

    Console.Clear();
    Console.WriteLine("Good bye, let's play again next time.");
}

