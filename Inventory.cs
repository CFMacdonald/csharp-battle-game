using System;
using System.Collections.Generic;

namespace PracticeApp
{
    class Inventory
    {
        private List<Item> items;
        private Character player;
      
        public Inventory()
        {
            items = new List<Item>();
        }
        
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
        
        public ItemEffect UseItem(ItemType itemType, Character character,ItemEffect itemEffect)
        {
            switch(itemType)
            {
                case ItemType.HealthPotion:
                int healAmmount = 10;
                character.Health += healAmmount;
                Console.WriteLine($"{character.Name} used {itemType} and restored {healAmmount} health.");
                items.Remove(items.Find(i => i.ItemType == ItemType.HealthPotion));
                return ItemEffect.Normal;

                case ItemType.ResistancePotion:
                int defenceAmmount = 3;
                character.Defence += defenceAmmount;
                Console.WriteLine($"{character.Name} used {itemType} and increased defence by {defenceAmmount}");
                items.Remove(items.Find(i => i.ItemType == ItemType.ResistancePotion));
                return ItemEffect.Normal;
                

                case ItemType.StealthPotion:
                Console.WriteLine($"{character.Name} used {itemType} and can now escape from battle.");
                items.Remove(items.Find(i => i.ItemType == ItemType.StealthPotion));
                return ItemEffect.CanEscape;
                
                default:
                Console.WriteLine("Invalid Item.");
                return ItemEffect.Normal;
            }

        }
       
        public void DisplayInventory()
        {
            int healthPotionAmmount = 0;
            int resistancePotionAmmount = 0;
            int stealthPotionAmmount = 0;

            foreach (Item item in items)
            {
                if(item.ItemType == ItemType.HealthPotion)
                {
                    healthPotionAmmount++;
                }
                else if(item.ItemType == ItemType.ResistancePotion)
                {
                    resistancePotionAmmount++;
                }
                else if(item.ItemType == ItemType.StealthPotion)
                {
                    stealthPotionAmmount++;
                }

            }
                Console.WriteLine("Inventory:");
                Console.WriteLine($"1.Health Potions: {healthPotionAmmount}");
                Console.WriteLine($"2.Resistance Potions: {resistancePotionAmmount}");
                Console.WriteLine($"3.Stealth Potions: {stealthPotionAmmount}");
        }
    }
}
