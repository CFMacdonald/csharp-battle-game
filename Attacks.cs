using System;

namespace PracticeApp
{
    class Attacks
    {
        private Character player;
        private Random random;

       
        public Attacks(Character player)
        {
            this.player = player;
            this.random = new Random();
        }

        public void LightAttack(Character target)
        {
            int baseDamage = this.player.AttackPower;
            int damage = CalculateAttackRange(baseDamage, 10, 40);

            Console.WriteLine($"{this.player.Name} uses Light Attack on {target.Name}!");
            Console.WriteLine($"Damage dealt: {damage}");
            
            target.TakeDamage(damage);
        }

        public void HeavyAttack(Character target)
        {
            int baseDamage = this.player.AttackPower * 2;
            int damage = CalculateAttackRange(baseDamage, 10, 20);
            
            Console.WriteLine($"{this.player.Name} uses Heavy Attack on {target.Name}!");
            Console.WriteLine($"Damage dealt: {damage}");
            
            target.TakeDamage(damage);
        }

        public void Blind(Character target)
        {
            int effect = this.player.Defence - 1;
            Console.WriteLine($"{this.player.Name} Blind {target.Name}!");
            Console.WriteLine($"Defence Down By: {effect}");
        }

        private int CalculateAttackRange(int baseDamage, int critChance, int missChance)
        {
            int chance = random.Next(1, 101);

            if (chance <= critChance)
            {
                baseDamage *= 2;
                Console.WriteLine("CRIT!");
            }
            else if (chance <= critChance + missChance)
            {
                baseDamage = 0;
                Console.WriteLine("MISS!");
            }

            return baseDamage;
        }
    }
}
