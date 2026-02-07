using System;

namespace PracticeApp
{
    class GameManager
    {

        private Character player1;
        private Enemy currentBattleEnemy;
        private Attacks playerAttack;
        

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
            Console.WriteLine("Generating Player Stats.....");
            Console.WriteLine("Please Input your Player Name:");

            string playerName = Console.ReadLine();

            Random random = new Random();
            int randomHealth = random.Next(1, 21);
            int randomAttackPower = random.Next(1, 11);
            int randomDefence = random.Next(1, 6);

            Character playerStats = new Character(playerName, randomHealth, randomAttackPower, randomDefence);
            return playerStats;
        }

        public void StartBattleSequence(Enemy enemy1)
        {
            currentBattleEnemy = enemy1;

            Console.WriteLine("Battle Started!");

            currentBattleEnemy.newEnemy.DisplayStats();

            while(currentBattleEnemy.newEnemy.Health > 0 && player1.Health > 0)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("Use attack: \n 1. Light Attack \n 2. Heavy Attack \n 3. Blind");

                switch (Console.ReadLine())
                {
                    case "1":
                    playerAttack = new Attacks(player1);
                    playerAttack.LightAttack(currentBattleEnemy.newEnemy);
                    break;
                    case "2":
                    playerAttack = new Attacks(player1);
                    playerAttack.HeavyAttack(currentBattleEnemy.newEnemy);
                    break;
                    case "3":
                    playerAttack = new Attacks(player1);
                    playerAttack.Blind(currentBattleEnemy.newEnemy);
                    break;
                    default:
                    Console.WriteLine("Invalid Input. Please enter '1', '2', or '3'.");
                    break;
                }

                if(currentBattleEnemy.newEnemy.Health > 0)
                {
                    currentBattleEnemy.BasicAttack(player1);
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------");

                
            }

            if(player1.Health > 0) 
                Console.WriteLine(player1.Name + " WON!");
            else 
                Console.WriteLine(player1.Name + " Died!");
        }
    }
}