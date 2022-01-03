using System;

namespace RandomGame_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomizer = new Random();
            int computer_randomNumber = randomizer.Next(1000);
            
            bool isDone = false;
            int counter = 0;
            while(!isDone){
                if(counter == 3){
                    if(IsEven(computer_randomNumber)) Print("Hint : It's Even" , ConsoleColor.Yellow);
                    else Print($"Hint : It's Odd" , ConsoleColor.Yellow);
                    //Print($"And between {computer_randomNumber-randomizer.Next(30,50)} and {computer_randomNumber+randomizer.Next(30,50)}" , ConsoleColor.Yellow);
                }
                if(counter == 6){
                    Print($"Game Over! It was {computer_randomNumber} 🖕🤪🖕" , ConsoleColor.Red);
                    isDone=true;
                    continue;
                }
                Console.ResetColor();
                Console.Write("🥳 Guess: ");
                var user_guessNumber_string = Console.ReadLine();
                int user_guessNumber;
                bool isSucceeded = int.TryParse(user_guessNumber_string , out user_guessNumber);
                if(isSucceeded){
                    counter++;
                    if(user_guessNumber == computer_randomNumber ){
                        Print("Well Done.🎉🎉🎉" , ConsoleColor.Green);
                        Print($"You did it in {counter} tries." , ConsoleColor.Blue);
                        isDone = true;
                        continue;
                    }
                    else if(user_guessNumber > computer_randomNumber){
                        Print("🔻 too high" , ConsoleColor.Red);
                    }
                    else{
                        Print("🔺 too low" , ConsoleColor.Red);
                    }
                }else{
                    Print("Bad input." , ConsoleColor.Red);
                }
            }

            
        }
    
    
        private static void Print(string message , ConsoleColor consoleColor = ConsoleColor.White , bool newLine = true){
            Console.ForegroundColor = consoleColor;
            //Console.SetCursorPosition(2 , Console.CursorTop-1);
            if(newLine){
                   Console.WriteLine(message);
            }else{
                 Console.Write(message);
            }
        }

        private static bool IsEven(int number){
            return number % 2 == 0;
        }
    }
}
