using System;
using System.Runtime.CompilerServices;

namespace PracticeApp
{
    class Enemy
    {
        public Character newEnemy;
        Inventory playerInventory;

        public Enemy(Character newEnemy) 
        {
            this.newEnemy = newEnemy;
        }   

        private static Character CreateEnemy(string enemyName, int health, int attackPower, int defence, int stamina)
        {
            Character newEnemy = new Character(enemyName, health, attackPower, defence, stamina);
            return newEnemy;
        }

        public static Character CreateClanker()
        {
            return CreateEnemy("Clanker", 10, 4, 2, 0);
        }

        public static Character CreateMech()
        {
            return CreateEnemy("Mech", 15, 5, 5, 0);
        }

        public static Character CreateNanobot()
        {
            return CreateEnemy("Nanobot", 5, 10, 1, 0);
        }

        public static Character CreateBionicOverlord()
        {
            return CreateEnemy("Bionic Overlord", 35, 9, 5, 0);
        }

        public void BasicAttack(Character target)
        {
            int damage = this.newEnemy.AttackPower;
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"{this.newEnemy.Name} attacks {target.Name}!");
            Console.WriteLine($"Damage dealt: {damage}");
            Console.ResetColor();
            target.TakeDamage(damage);
        }

        public void SpecialAttack(Character target)
        {
            int damage = this.newEnemy.AttackPower *2;
            
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"{this.newEnemy.Name} uses its Special Attack!!");
            Console.WriteLine($"Damage dealt: {damage}, Defence and Stamina Drained!");
            Console.ResetColor();
            target.DrainDefence(1);
            target.DrainStamina(2);
            target.TakeDamage(damage);
        }

        public void NanobotSpecialAttack(Character target, Inventory playerInventory)
        {
            if(playerInventory.HasItemOfType(ItemType.HealthPotion))  
            {
                Item stolen = playerInventory.GetItemByType(ItemType.HealthPotion); 
                playerInventory.RemoveItem(stolen); 
                Console.WriteLine($"The nanobot steals a health potion and uses it to heal itself! Health: {this.newEnemy.Health + 5}");
                this.newEnemy.Health += 5;
                BasicAttack(target);
            }
            else
            {
                Console.WriteLine("The nanobot tries to steal, but you have no health potions!");
                BasicAttack(target);
            }
        }

        public void SkipNextTurn(Character target)
        {
            BasicAttack(target);
        }  
    
    }
}
