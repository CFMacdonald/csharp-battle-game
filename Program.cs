using System;

namespace PracticeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GameManager gameManager = new GameManager();
            gameManager.StartGame();

            gameManager.DelayStatment(2000);

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("The fluorescent lights overhead flicker and hum, casting long shadows across the laboratory.");
            Console.WriteLine("As you step over a pile of discarded copper wiring, a metallic clatter rings out from the darkness.");
            Console.WriteLine("A small, boxy security clanker rolls into the light, its single red sensor lens focusing on you.");
            Console.WriteLine("The machine emits a high-pitched digital screech, and its cooling fans begin to whir aggressively.");
            Console.WriteLine("It deploys a small stun-prod from its chassis. It isn't letting you pass without a fight.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(1000);

            Enemy enemy1 = new Enemy(Enemy.CreateClanker());
            gameManager.TryToRun(enemy1);
            gameManager.DelayStatment(2000);

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Once the clanker is defeated, you cautiously step over its motionless body and continue down the dimly lit corridor.");
            Console.WriteLine("The air grows colder, and the distant sound of machinery echoes through the halls. As you turn a corner, a larger, more heavily armored mech emerges from the shadows.");
            Console.WriteLine("Its imposing frame is covered in reinforced plating, and its glowing red eyes lock onto you with deadly intent.");
            Console.WriteLine("The mech's powerful servos whir to life as it prepares to engage you in combat.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(2000);
            Enemy enemy2 = new Enemy(Enemy.CreateMech());
            gameManager.TryToRun(enemy2);

            gameManager.DelayStatment(2000);

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("As the heavy Mech collapses with a deafening metallic crash, the silence that follows is even more unsettling.");
            Console.WriteLine("You push deeper into the facility, noticing the walls are now covered in a strange, shimmering silver dust.");
            Console.WriteLine("Suddenly, the 'dust' begins to swirl and vibrate, emitting a high-pitched hum that vibrates in your teeth.");
            Console.WriteLine("The particles coalesce into a swarming, translucent mass—a Nanobot Hive, pulsing with a faint blue light.");
            Console.WriteLine("It doesn't roar; it simply begins to disassemble the air around you as it surges forward.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(2000);

            Enemy enemy3 = new Enemy(Enemy.CreateNanobot());
            gameManager.TryToRun(enemy3);
            gameManager.DelayStatment(2000);

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("You barely have time to catch your breath when a sudden, electric chill fills the air.");
            Console.WriteLine("From a vent above, a second nanobot swarm pours out, its metallic particles glinting in the emergency lights.");
            Console.WriteLine("The nanobots surge toward you in a coordinated ambush, intent on overwhelming you before you can react.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(2000);
            Enemy enemy4 = new Enemy(Enemy.CreateNanobot());
            gameManager.TryToRun(enemy4);
            gameManager.DelayStatment(2000);

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("As you stagger forward, battered but alive, the facility suddenly shakes with a deep, mechanical rumble.");
            Console.WriteLine("A massive door slides open at the end of the corridor, revealing a towering figure wreathed in sparks and shadow.");
            Console.WriteLine("The Bionic Overlord steps into the light, its eyes burning with cold intelligence. This is the final test.");
            Console.WriteLine("Prepare yourself for the ultimate battle!");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(2000);
            Enemy boss = new Enemy(Enemy.CreateBionicOverlord());
            gameManager.TryToRun(boss);
            gameManager.DelayStatment(2000);

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("The alarms finally fall silent. The Bionic Overlord collapses, sparks flying, and the facility doors unlock with a hiss of escaping air.");
            Console.WriteLine("You step out into the dawn, free at last. Congratulations—you have survived Sector 7!");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(2000);

            Console.WriteLine("Would you like to play again? (y/n)");
            string playAgainInput = Console.ReadLine().ToLower();
            if (playAgainInput == "y" || playAgainInput == "yes")
            {
                gameManager.StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}





