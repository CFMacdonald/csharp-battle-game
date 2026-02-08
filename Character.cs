using System;

namespace PracticeApp
{
    class Character
    {
        public string Name {get; set;}
        public int Health {get; set;}
        public int MaxHealth {get; set;}
        public int AttackPower {get; set;}
        public int Defence {get; set;}
        public int Stamina {get; set;}

        public Character(string name, int health, int attackPower, int defence, int stamina)
        {
            this.Name = name;
            this.Health = health;   
            this.AttackPower = attackPower;
            this.Defence = defence;
            this.Stamina = stamina;
            
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}\nHealth: {Health}\nAttack Power: {AttackPower}\nDefence: {Defence}\nStamina: {Stamina}");
        }
        
        public void TakeDamage(int damage)
        {
            int trueDamage = damage - Defence;  
            
            if(trueDamage < 0) trueDamage = 0;  
            
            Health -= trueDamage;  
            
            if(Health < 0) Health = 0;  
            
            Console.WriteLine($"{Name} takes {trueDamage} damage! Health Remaining: {Health}");
        }

        public static void Heal(Character target, int healAmount)
        {
            int healResult = target.Health + healAmount; 
            if(healResult > target.MaxHealth) healResult = target.MaxHealth;
            target.Health = healResult;  

            Console.WriteLine($"{target.Name} healed for {healAmount} Health! Current Health: {target.Health}");
        }
      
    }
}