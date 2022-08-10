namespace WarCroft.Core
{

	using System;
	using System.Linq;
	using System.Collections.Generic;

    using WarCroft.Constants;
	using WarCroft.Entities.Items;
	using WarCroft.Entities.Characters;
	using WarCroft.Entities.Characters.Contracts;
    using System.Text;

    public class WarController
	{
		private List<Character> party;
		private Stack<Item> itemPool;


		public WarController()
		{
			party = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string characterName = args[1];

			Character character = characterType switch
			{
				nameof(Priest) => new Priest(characterName),
				nameof(Warrior) => new Warrior(characterName),
				_ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType))
			};

			party.Add(character);
			return string.Format(SuccessMessages.JoinParty, characterName);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = itemName switch
			{
				nameof(HealthPotion) => new HealthPotion(),
				nameof(FirePotion) => new FirePotion(),
				_ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName))
			};

			itemPool.Push(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = party.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

            if (!itemPool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = itemPool.Pop();
			character.Bag.AddItem(item);

			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);

		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = party.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder result = new StringBuilder();

            foreach (Character character in party.OrderByDescending(c => c.IsAlive)
											     .ThenByDescending(c => c.Health))
            {
				result.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {string.Format(character.IsAlive ? "Alive" : "Dead")}");
            }

			return result.ToString();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string defenderName = args[1];

            if (!party.Any(c => c.Name == attackerName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}

			if (!party.Any(c => c.Name == defenderName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, defenderName));
			}

			Character attacker = party.FirstOrDefault(c => c.Name == attackerName);

			if (attacker.GetType().Name != "Warrior")
			{
				throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
			}

			Warrior warrior = party.FirstOrDefault(c => c.Name == attackerName) as Warrior;
			Character defender = party.FirstOrDefault(c => c.Name == defenderName);


			warrior.Attack(defender);

			StringBuilder result = new StringBuilder();

			result.AppendLine($"{attackerName} attacks {defenderName} for {attacker.AbilityPoints} hit points! {defenderName} has {defender.Health}/{defender.BaseHealth} HP and {defender.Armor}/{defender.BaseArmor} AP left!");

            if (!defender.IsAlive)
            {
				result.AppendLine($"{defenderName} is dead!");
            }

			return result.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		
		{
			string healerName = args[0];
			string recieverName = args[1];

			if (!party.Any(c => c.Name == healerName))
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
			}

			if (!party.Any(c => c.Name == recieverName))
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, recieverName);
			}

			Character healer = party.FirstOrDefault(c => c.Name == healerName);

			if (healer.GetType().Name != "Priest")
			{
				throw new ArgumentException(ExceptionMessages.AttackFail, healerName);
			}


			Priest priest = party.FirstOrDefault(c => c.Name == healerName) as Priest;
			Character receiver = party.FirstOrDefault(c => c.Name == recieverName);

			priest.Heal(receiver);
			StringBuilder result = new StringBuilder();

			result.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

			return result.ToString().TrimEnd();
		}
	}
}
