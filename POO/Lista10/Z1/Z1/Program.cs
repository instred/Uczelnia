using System;
using Unity;

namespace Z1 {
	internal static class Program {
		private static void CompositionRoot() {
			var container = new UnityContainer();
			LocalFactory.OrmProvider = () => container.Resolve<Orm>();
		}

		private static void InsertParent(Orm orm) {
			var parent = new Parent();
			orm.InsertParent(parent);
			Console.WriteLine("Inserted parent with id = " + parent.Id + ".");
		}

		private static void InsertChild(Orm orm) {
			Console.WriteLine("Enter parents id:");
			var parentId = int.Parse(Console.ReadLine() ?? string.Empty);
			var child = new Child(orm.ParentFromId(parentId));
			orm.InsertChild(child);
			Console.WriteLine("Inserted child with id = " + child.Id + ".");
		}

		private static void CheckParent(Orm orm) {
			Console.WriteLine("Enter childs id:");
			var id = int.Parse(Console.ReadLine() ?? string.Empty);
			Console.WriteLine("Parents id = " + orm.ChildFromId(id).Parent.Id);
		}

		public static void Main() {
			CompositionRoot();

			var factory = new LocalFactory();
			var orm = LocalFactory.CreateORM();

			Console.WriteLine("How many operations do you want to perform?");
			var operationsCount = int.Parse(Console.ReadLine() ?? string.Empty);

			for (var i = 0; i < operationsCount; i++) {
				Console.WriteLine("Do you want to insert parent (ip), insert child (ic) or check childs parent (cp)?");
				var choice = Console.ReadLine();

				switch (choice) {
					case "ip":
						InsertParent(orm);
						break;
					case "ic":
						InsertChild(orm);
						break;
					case "cp":
						CheckParent(orm);
						break;
				}
			}
		}
	}

	public class Parent {
		private static int _lastId;
		public int Id { get; }

		public Parent() {
			Id = NextId();
		}

		public Parent(int id) {
			Id = id;
		}

		private static int NextId() {
			return _lastId++;
		}
	}

	public class Child {
		private static int _lastId;
		public int Id { get; }
		public Parent Parent { get; }

		public Child(Parent parent) {
			Id = NextId();
			Parent = parent;
		}

		public Child(int id, Parent parent) {
			Id = id;
			Parent = parent;
		}

		private static int NextId() {
			return _lastId++;
		}
	}
}