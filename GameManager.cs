using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace PracticeApp
{
    class GameManager
    {

        private Character player;
        private Enemy currentBattleEnemy;
        private Attacks playerAttack;
        private Inventory inventory;

        Random random = new Random();

        bool escapeSuccess = false;
        

        public void StartGame()
        {
            Console.WriteLine("Hello! Do you want to start?");

            bool validInput = false;

            while (!validInput)
            {
                string startGameInput = Console.ReadLine().ToLower();

                if (startGameInput == "yes" || startGameInput == "y")
                {
                    player = CreatePlayer();
                    player.DisplayStats();

                    inventory = new Inventory();
                    inventory.AddItem(Item.CreateHealthPotion());
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
            int randomAttackPower = random.Next(4, 11);
            int randomDefence = random.Next(1, 4);
            int stamina = 5;

            Character playerStats = new Character(playerName, randomHealth, randomAttackPower, randomDefence, stamina);
            playerStats.MaxHealth = maxHealth;
            return playerStats;
        }

        public void StartBattleSequence(Enemy enemy)
        {
            currentBattleEnemy = enemy;

            playerAttack = new Attacks(player);

            Console.WriteLine("\n--- INITIATING COMBAT ---");
            DelayStatment(2000);
            currentBattleEnemy.newEnemy.DisplayStats();

            while (currentBattleEnemy.newEnemy.Health > 0 && player.Health > 0 && !escapeSuccess)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("What do you want to do?");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"--- Total Stamina: {player.Stamina} ---");
                Console.ResetColor();
                Console.WriteLine($"1. Light Attack. Stamina Cost: {playerAttack.staminaCostLight}");
                Console.WriteLine($"2. Heavy Attack. Stamina Cost: {playerAttack.staminaCostHeavy}");
                Console.WriteLine($"3. Blind. Stamina Cost: {playerAttack.staminaCostBlind}");
                Console.WriteLine("4. Rest");
                Console.WriteLine("5. Display Inventory");
                Console.WriteLine("6. Use Item");

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
                        Console.WriteLine($"{player.Name} takes a moment to rest and recover stamina.");
                        player.Stamina += 5;
                        if (player.Stamina > 5) player.Stamina = 5;
                        Console.WriteLine($"Stamina Restored. Current Stamina: {player.Stamina}");
                        break;
                    case "5":
                        inventory.DisplayInventory();
                        continue;
                    case "6":
                        UseItemMenu();
                        continue;
                    case "7":
                        EndBattleSequence();
                        return;
                    default:
                        Console.WriteLine("Invalid Input. Please enter '1', '2', '3', '4', '5' or '6'.");
                        continue;
                }

                if (currentBattleEnemy.newEnemy.Health > 0)
                {
                    currentBattleEnemy.BasicAttack(player);
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------");
            }
            
            WinOrLoseCondidtion();
}

        private void WinOrLoseCondidtion()
        {
            if (player.Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(player.Name + " WON!");
                Character.Heal(player, 5);
                Item winReward = Item.RollRandomLoot();
                Console.WriteLine($"You Recieve: {winReward.Name} - {winReward.Description}");
                inventory.AddItem(winReward);
                Console.ResetColor();

            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(player.Name + " Died! GAME OVER!");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }

        public void DelayStatment(int time)
        {
            System.Threading.Thread.Sleep(time);
        }
    
        public void TryToRun(Enemy enemy)
        {
            Console.WriteLine("Would you like to try and run away? Yes or No?");
            string runAwayInput = Console.ReadLine().ToLower();

            if(runAwayInput == "yes")
            {
                int runChance = random.Next(1,100);

                if(runChance < 20)
                {
                    Console.WriteLine($"You Sucsessfully Ran Away! Drained all your Stamina");
                    player.Stamina = 0;
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
                TryToRun(enemy);
            }

        }
    
        public void UseItemMenu()
        {
            Console.WriteLine("Which item would you like to use? Please enter the corresponding number.");
            inventory.DisplayInventory();
            string itemChoice = Console.ReadLine();

            switch(itemChoice)
            {
                case "1":
                inventory.UseItem(ItemType.HealthPotion,player,ItemEffect.Normal);
                break;
                case "2":
                inventory.UseItem(ItemType.ResistancePotion,player,ItemEffect.Normal);
                break;
                case "3":
                ItemEffect itemEffect = inventory.UseItem(ItemType.StealthPotion,player,ItemEffect.CanEscape);
                if(itemEffect == ItemEffect.CanEscape)
                {
                    EndBattleSequence();
                }
                break;
                default:
                Console.WriteLine("Invalid Input. Please enter '1', '2' or '3'.");
                UseItemMenu();
                break;
            }
        }

        public void EndBattleSequence()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Escaped the Battle!");
            Console.ResetColor();
            DelayStatment(2000);
            escapeSuccess = true;
        }

    }
}