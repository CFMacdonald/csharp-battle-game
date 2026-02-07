using System;

namespace PracticeApp
{
    class Character
    {
        public string Name {get; set;}
        public int Health {get; set;}
        public int AttackPower {get; set;}
        public int Defence {get; set;}

        public Character(string name, int health, int attackPower, int defence)
        {
            this.Name = name;
            this.Health = health;   
            this.AttackPower = attackPower;
            this.Defence = defence;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}\nHealth: {Health}\nAttack Power: {AttackPower}\nDefence: {Defence}");
        }
        
        public void TakeDamage(int damage)
        {
            int trueDamage = damage - Defence;  
            
            if(trueDamage < 0) trueDamage = 0;  
            
            Health -= trueDamage;  
            
            if(Health < 0) Health = 0;  
            
            Console.WriteLine($"{Name} takes {trueDamage} damage! Health: {Health}");
        }

       
    }
}