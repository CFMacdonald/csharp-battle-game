using System;

namespace PracticeApp
{
    class Attacks
    {
        private Character player;
        private Random random;
        
        public int staminaCostLight = 2;
        public int staminaCostHeavy = 3;
        public int staminaCostBlind = 2;

       
        public Attacks(Character player)
        {
            this.player = player;
            this.random = new Random();
        }

        public void LightAttack(Character target)
        {
            if (HasEnoughStamina(staminaCostLight))
                {
                    int baseDamage = this.player.AttackPower;
                    player.Stamina -= staminaCostLight;

                    Console.WriteLine($"{this.player.Name} uses Light Attack on {target.Name}! Stamina Remaining: {player.Stamina}");
                    int damage = CalculateAttackRange(baseDamage, 10, 40);
                    Console.WriteLine($"Damage dealt: {damage}");

                    target.TakeDamage(damage);
            }
            else
                {
                    Console.WriteLine("Not Enough Stamina! You need rest!");
                }
    }

        public void HeavyAttack(Character target)
        {
            if (HasEnoughStamina(staminaCostHeavy))
            {
                int baseDamage = this.player.AttackPower * 2;
                player.Stamina -= staminaCostHeavy;

                Console.WriteLine($"{this.player.Name} uses Heavy Attack on {target.Name}! Stamina Remaining: {player.Stamina}");
                int damage = CalculateAttackRange(baseDamage, 10, 20);
                Console.WriteLine($"Damage dealt: {damage}");

                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine("Not Enough Stamina! You need rest!");
            }
        }

        public void Blind(Character target)
        {
            if (HasEnoughStamina(staminaCostBlind))
            {
                int effect = 2;
                player.Stamina -= staminaCostBlind;
                target.Defence -= effect;
                target.AttackPower -= effect;
                Console.WriteLine($"{this.player.Name} Blind {target.Name}! Stamina Remaining: {player.Stamina}");
                Console.WriteLine($"Defence Down By: {effect}");
                Console.WriteLine($"Attack Power Down By: {effect}");
            }
            else
            {
                Console.WriteLine("Not Enough Stamina! You need rest!");
            }
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

        public bool HasEnoughStamina(int staminaCost)
        {
            if(staminaCost > player.Stamina) return false;
            else return true;

        }
    }
}

