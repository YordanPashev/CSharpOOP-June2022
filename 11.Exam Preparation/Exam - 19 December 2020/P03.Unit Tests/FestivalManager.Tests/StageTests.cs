// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    
    using System;
    using System.Linq;

	using NUnit.Framework;

	//Must be delete for submition into Judge System
	using FestivalManager.Entities;

	[TestFixture]
	public class StageTests
	{
		private Stage stage;

		[SetUp]
		public void SetUp() => this.stage = new Stage();
		
		[Test]
		public void Test_Stage_Constructor_Must_Create_Stage_With_Given_Values()
		{
			Assert.That(this.stage != null && this.stage.Performers.Count == 0,
						"Constructor does not works. Must create new stage with perfomers count 0.");
		}

		[TestCase("Slavi", "Trifonov", 55)]
		[TestCase("Nidqlku", "Ivanov", 45)]
		public void Test_AddPerformer_Method_Must_Add_New_Performer_To_The_List
			(string performerFistName, string performerLastName, int performerAge)
		{
			Performer performer = new Performer(performerFistName, performerLastName, performerAge);
			int expectedPerformersCount = 1;

			this.stage.AddPerformer(performer);

			Assert.That(this.stage.Performers.Count == expectedPerformersCount,
						$"The mothod does not add performer to the stage. Performer count must be {expectedPerformersCount}.");
		}

		[Test]
        public void Test_AddPerformer_Method_Must_Throw_Null_Exception()
        {
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null),
					"Must throw error because the performer is null.");
		}

		[TestCase("Emko", "Sifonia", 15)]
		[TestCase("MC", "Faronq", 12)]
		public void Test_AddPerformer_Method_Must_Error_Because_The_Performer_Is_Under_18
			(string performerFistName, string performerLastName, int performerAge)
        {
			Performer performer = new Performer(performerFistName, performerLastName, performerAge);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer),
					"Must throw error because the performer is under 18.");
		}

		[Test]
		public void Test_AddSong_Method_Must_Throw_Null_Exception()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null),
					"Must throw error because the song is null.");
		}

		[TestCase("Shti skysam gyza", 59)]
		[TestCase("Kurvi sbogom", 1)]
		public void Test_AddSong_Method_Must_Error_Because_A_Song_Cant_Have_A_Duration_Uder_One_Minute
			(string songName, int songDurationInSeconds)
		{
			TimeSpan duration = TimeSpan.FromSeconds(songDurationInSeconds);

			Song song = new Song(songName, duration);

			Assert.Throws<ArgumentException>(() => stage.AddSong(song),
					"Must throw error because a song can not have a duration under 1 minute");
		}

		[Test]
		public void Test_AddSongToPerformer_Method_Must_Throw_Null_Exception_Song_Is_Null()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Bako Ivan"),
					"Must throw error because the song can not be null.");
		}

		[Test]
		public void Test_AddSongToPerformer_Method_Must_Throw_Null_Exception_performer_Is_Null()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Koi ushiba radka", null),
					"Must throw error because the performer can not be null.");
		}

		[TestCase("Shti skysam gyza", 253, "Slavi", "Trifonov", 55)]
		[TestCase("Kurvi sbogom", 420, "Rado", "Shisharkata", 22)]
		public void Test_AddSongToPerformer_Method_Must_Return_Add_Message
			(string songName, int songDurationInSeconds,
			string performerFistName, string performerLastName, int performerAge)
        {
			TimeSpan duration = TimeSpan.FromSeconds(songDurationInSeconds);
			Song song = new Song(songName, duration);
			Performer performer = new Performer(performerFistName, performerLastName, performerAge);
			string exptectedResult = $"{song} will be performed by {performer}";

			stage.AddSong(song);
			stage.AddPerformer(performer);
			string addResult = stage.AddSongToPerformer(song.Name, performer.FullName);

			Assert.That(addResult == exptectedResult,
						"The method does not add given song to the given performer");		
		}

		[TestCase("Shti skysam gyza", 253, "Slavi", "Trifonov", 55)]
		[TestCase("Kurvi sbogom", 420, "Rado", "Shisharkata", 22)]
		public void Test_Play_Mehotd_Must_Return_The_Count_Of_All_Songs
			(string songName, int songDurationInSeconds,
			string performerFistName, string performerLastName, int performerAge)
		{
			TimeSpan duration = TimeSpan.FromSeconds(songDurationInSeconds);
			Song song = new Song(songName, duration);
			Performer performer = new Performer(performerFistName, performerLastName, performerAge);
			int expectedPerformers = 1;
			int expectedSongs = 1;
			string exptectedResult = $"{expectedPerformers} performers played {expectedSongs} songs";

			stage.AddSong(song);
			stage.AddPerformer(performer);
			string addResult = stage.AddSongToPerformer(song.Name, performer.FullName);
			string playResult = stage.Play();

			Assert.That(playResult == exptectedResult,
						"The method does not add given song to the given performer");
		}
	}
}