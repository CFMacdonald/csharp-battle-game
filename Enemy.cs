using System;

namespace PracticeApp
{
    class Enemy
    {
        public Character newEnemy;

        public Enemy(Character newEnemy) 
        {
            this.newEnemy = newEnemy;
        }   

        private static Character CreateEnemy(string enemyName, int health, int attackPower, int defence, int stamina)
        {
            Character newEnemy = new Character(enemyName, health, attackPower, defence, stamina);
            return newEnemy;
        }

        public static Character CreateSmallRobot()
        {
            return CreateEnemy("Small Robot", 10, 5, 2, 0);
        }

        public void BasicAttack(Character target)
        {
            int damage = this.newEnemy.AttackPower;
            Console.WriteLine($"{this.newEnemy.Name} attacks {target.Name}!");
            Console.WriteLine($"Damage dealt: {damage}");
            target.TakeDamage(damage);
        }

        
    }
}
