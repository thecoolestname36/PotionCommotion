using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PotionCommotion.Entities {
	public class Potion {

		[Key]
		public int Id { get; set; }
		public string Description { get; set; } = "";
		public string ImageClass { get; set; } = "";
		public bool Selected { get; set; } = false;

		public string GetViewImageClass() {
			if (!this.Selected) {
				return this.ImageClass;
			}
			return "";
		}

		public static string GetImageClass(int item) {
			switch (item) {
				case 0: return "green";
				case 1: return "blue";
				case 2: return "red";
				default: return "";
			}
		}

		public static void ResetContext() {

			var context = new PCContext();
			foreach (var potion in context.Potions.ToList()) {
				context.Potions.Remove(potion);
			}
			context.SaveChanges();

			var r = new Random();
			var min = 0; // inclusive
			var max = 3; // non-inclusive
			int i = 0;
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Your skin hardens, +1 natural AC. This is an enhancement bonus." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You no longer require water to live." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You can change your dialect to Aundairian at will." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You gain the ability to draw; you gain the feat Skill focus: Craft (Forgery)" });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Your legs strengthen; you gain Skill Focus: Athletics" });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You can Speak with Animals 3 times per day." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You gain the answer to a simple question (a la Augury)" });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "While in natural sunlight, your swim speed increases by 10’ " });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Your boots allow you to walk on bases." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "The next book you write will be a posthumous best-seller.." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Your touch can slowly bring small objects to pleasantly cool." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You grow 1 year younger." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You become even more quick-witted. Gain the feat Skill Focus (Diplomacy)" });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You learn to play an instrument. Gain a rank in Perform for it." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Your anger seeps out sometimes. You can rage as a barbarian for 3 rounds per day." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Gain a trait for your region." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You can stand really still. Gain +5 stealth when not moving." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You can change your hair color at will." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You increase your knowledge of bodies; gain Skill Focus: Heal." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You always identify South on Eberron." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You shifty sonuvabitch; gain skill focus Bluff." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Your soft weapons are dangerous; increase the crit modifier of non-lethal weapons by 1." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You know the price of everything and the value of nothing. Gain skill focus Appraise." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You understand machines; gain skill focus Disable Device." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Angelic voices sing softly when you enter a room." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You become double jointed. Gain skill focus Escape Artist." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "*anime eyes* gain skill focus Perception" });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You can cast Levitate once per day." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You are the capybara whisperer. Gain skill focus Handle Animal." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "*eye twitch* gain skill focus Intimidate." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You learn to speak Argon, the language of the barbarians of Argonnessen." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Yeehaw cowboy. Gain skill focus Ride." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Don’t trust that dame. Gain skill focus Sense Motive." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You understand the working of magic. Gain skill focus Spellcraft." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Creepy Crawlies. You can use your Intimidate skill to demoralize animals and vermin." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Kobolds instinctively trust you." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Squish tiny humans. Gain +1 on melee attack rolls against creatures smaller than you." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Math comes easily to you. Gain skill focus: Knowledge Engineering." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "#Blessed. Once per day as a swift action, +1 bonus on all saving throws for 1 round." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "Rocksteady. Once per day, you may take 9 on an initiative check." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "You gain one additional 0-level spell slot. If you don’t cast spells, learn Prestidigitation." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "#MonestaryLife. You gain proficiency in a monk weapon." });
			context.Potions.Add(new Potion() { Id = ++i, ImageClass = GetImageClass(r.Next(min, max)), Description = "A nice quiet bar. You gain a +2 trait bonus on weapon damage rolls with improvised weapons." });
			
			context.SaveChanges();
		}

	}

}
