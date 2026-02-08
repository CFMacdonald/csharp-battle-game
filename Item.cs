using System;

namespace PracticeApp
{

    enum ItemEffect
    {
        Normal,
        CanEscape,
    }


    enum ItemType
    {
        HealthPotion,
        ResistancePotion,
        StealthPotion,
    }
    class Item
    {
       public string Name {get; set;}
       public string Description {get; set;}
       public ItemType ItemType {get; set;}
       public int BaseEffectValue {get; set;}

        public Item(string name, string description, ItemType itemType, int baseEffectValue)
        {
            this.Name = name;
            this.Description = description;
            this.ItemType = itemType;
            this.BaseEffectValue = baseEffectValue;
        }

    public static Item CreateNewItem(string name, string description, ItemType itemType, int baseEffectValue)
    {
        Item newItem = new Item(name, description, itemType, baseEffectValue);
        return newItem;
    }

    public static Item CreateHealthPotion()
    {
        return CreateNewItem("Health Potion", "Restores 5 Health", ItemType.HealthPotion, 5);
    }
          
    public static Item CreateResistancePotion()
    {
        return CreateNewItem("Resistance Potion", "Increases resistance by 5", ItemType.ResistancePotion, 5);
    }

    public static Item CreateStealthPotion()
    {
        return CreateNewItem("Stealth Potion", "Increases stealth by 5", ItemType.StealthPotion, 5);
    }

    public static Item RollRandomLoot()
    {
        Random random = new Random();
        int randomRollValue = random.Next(1,4);
        if(randomRollValue == 1)
        {
            return CreateHealthPotion();
        }
        else if(randomRollValue == 2)
        {
            return CreateResistancePotion();
        }
        else return (CreateStealthPotion());

   }
  }
}
