using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
	public class NoteManager : IUserInterfaceManager
	{
		private readonly IUserInterfaceManager _parentUI;
		private string _connectionString;
		private NoteRepository _noteRepository;

		public NoteManager(IUserInterfaceManager parentUI, string connectionString)
		{
			_parentUI = parentUI;
			_connectionString = connectionString;
			_noteRepository = new NoteRepository(connectionString);
		}

		public IUserInterfaceManager Execute()
		{
			Console.WriteLine("Note Menu");
			Console.WriteLine(" 1) List Notes");
			Console.WriteLine(" 2) Note Details");
			Console.WriteLine(" 3) Add Note");
			Console.WriteLine(" 4) Edit Note");
			Console.WriteLine(" 5) Remove Note");
			Console.WriteLine(" 0) Go Back");

			Console.Write("> ");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					List();
					return this;
				case "2":
					return this;
				case "3":
					Add();
					return this;
				case "4":
					Edit();
					return this;
				case "5":
					Remove();
					return this;
				case "0":
					return _parentUI;
				default:
					Console.WriteLine("Invalid Selection");
					return this;
			}
		}

		private void List()
		{
			Console.WriteLine("Current notes: ");
			List<Note> notes = _noteRepository.GetAll();
			foreach (Note n in notes)
			{
				Console.WriteLine($"{n.Id} )  {n.Title}: {n.Content} -- {n.CreateDateTime}");
			}
			Console.WriteLine("");
		}
		private void Add()
		{
			throw new NotImplementedException();
		}

		private void Edit()
		{
			throw new NotImplementedException();
		}

		private void Remove()
		{
			throw new NotImplementedException();
		}
	}
}
