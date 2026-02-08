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
            Console.WriteLine("A small, boxy security drone rolls into the light, its single red sensor lens focusing on you.");
            Console.WriteLine("The machine emits a high-pitched digital screech, and its cooling fans begin to whir aggressively.");
            Console.WriteLine("It deploys a small stun-prod from its chassis. It isn't letting you pass without a fight.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            gameManager.DelayStatment(1000);

            Enemy enemy1 = new Enemy(Enemy.CreateSmallRobot());
            gameManager.TryToRun(enemy1);
            gameManager.DelayStatment(2000);

            Console.WriteLine("Debug: EscapeBattleWorked!");
          
            
        } 
    }
}




