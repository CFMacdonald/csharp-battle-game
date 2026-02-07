using System;

namespace PracticeApp
{
    class GameManager
    {

        private Character player1;
        private Enemy currentBattleEnemy;
        private Attacks playerAttack;

        Random random = new Random();
        

        public void StartGame()
        {
            Console.WriteLine("Hello! Do you want to start?");

            bool validInput = false;

            while (!validInput)
            {
                string startGameInput = Console.ReadLine().ToLower();

                if (startGameInput == "yes" || startGameInput == "y")
                {
                    player1 = CreatePlayer();
                    player1.DisplayStats();
                    validInput = true;
                }
                else if (startGameInput == "no" || startGameInput == "n")
                {
                    Environment.Exit(0);
                }
                else 
                {
                    Console.WriteLine("Invalid Input. Please enter 'yes' or 'no'.");
                }
            }
        }

        private Character CreatePlayer()
        {
            
            Console.WriteLine("Please Input your Player Name:");
            string playerName = Console.ReadLine();
            Console.WriteLine("Generating Player Stats.....");
            DelayStatment(2000);

            int randomHealth = random.Next(10, 21);
            int maxHealth = randomHealth;
            int randomAttackPower = random.Next(1, 11);
            int randomDefence = random.Next(1, 4);
            int stamina = 5;

            Character playerStats = new Character(playerName, randomHealth, randomAttackPower, randomDefence, stamina);
            playerStats.MaxHealth = maxHealth;
            return playerStats;
        }

        public void StartBattleSequence(Enemy enemy1)
        {
            currentBattleEnemy = enemy1;

            playerAttack = new Attacks(player1);

            Console.WriteLine("\n--- INITIATING COMBAT ---");
            DelayStatment(2000);
            currentBattleEnemy.newEnemy.DisplayStats();

            while(currentBattleEnemy.newEnemy.Health > 0 && player1.Health > 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine($"--- Total Stamina: {player1.Stamina} ---");
                Console.WriteLine($"1. Light Attack. Stamina Cost: {playerAttack.staminaCostLight}");
                Console.WriteLine($"2. Heavy Attack. Stamina Cost: {playerAttack.staminaCostHeavy}");
                Console.WriteLine($"3. Blind. Stamina Cost: {playerAttack.staminaCostBlind}");
                Console.WriteLine("4. Rest");

                switch (Console.ReadLine())
                {
                    case "1":
                    playerAttack.LightAttack(currentBattleEnemy.newEnemy);
                    break;
                    case "2":
                    playerAttack.HeavyAttack(currentBattleEnemy.newEnemy);
                    break;
                    case "3":
                    playerAttack.Blind(currentBattleEnemy.newEnemy);
                    break;
                    case "4":
                    Console.WriteLine($"{player1.Name} takes a moment to rest and recover stamina.");
                    player1.Stamina += 5;
                    if(player1.Stamina > 5) player1.Stamina = 5;
                    Console.WriteLine($"Stamina Restored. Current Stamina: {player1.Stamina}");
                    break;
                    default:
                    Console.WriteLine("Invalid Input. Please enter '1', '2', '3', or '4'.");
                    break;
                }

                if(currentBattleEnemy.newEnemy.Health > 0)
                {
                    currentBattleEnemy.BasicAttack(player1);
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------");
            }

            if(player1.Health > 0) 
            {
                Console.WriteLine(player1.Name + " WON!");

                player1.Health += 5;

                if(player1.Health > player1.MaxHealth) 
                {   
                    player1.Health = player1.MaxHealth;
                }

                Console.WriteLine($"{player1.Name} recovers 5 Health! Current Health: {player1.Health}");  
            }

            else 
                Console.WriteLine(player1.Name + " Died! GAME OVER!");
                Environment.Exit(0);
        }
    
        public void DelayStatment(int time)
        {
            System.Threading.Thread.Sleep(time);
        }
    
        public void TryToRunAway(Enemy enemy)
        {
            Console.WriteLine("Would you like to try and run away? Yes or No?");
            string runAwayInput = Console.ReadLine().ToLower();

            if(runAwayInput == "yes")
            {
                int runChance = random.Next(1,100);

                if(runChance < 20)
                {
                    Console.WriteLine($"You Sucsessfully Ran Away! Drained all your Stamina");
                    player1.Stamina = 0;
                }
                else
                {
                    Console.WriteLine("Failed");
                    StartBattleSequence(enemy);
                    
                }
            }
            else if(runAwayInput == "no")
            {
                StartBattleSequence(enemy);
            }
            else
            {
                Console.WriteLine("Invalid Input. Please enter 'yes' or 'no'.");
                TryToRunAway(enemy);
            }

        }
    }
}