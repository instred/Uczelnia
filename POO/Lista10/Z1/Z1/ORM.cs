using System.Collections.Generic;
using System.Data.SQLite;

namespace Z1 {
    public class Orm {
        private SQLiteConnection Connection { get; set; }

        private Dictionary<int, Parent> IdToParent { get; }
        private Dictionary<int, Child> IdToChild { get; }

        public Orm() {
            Connection = new SQLiteConnection(
                "Data Source=C:\\Users\\jakub\\Desktop\\Uczelnia\\POO\\Lista10\\Z1\\db.sqlite; Version=3;");
            Connection.Open();

            IdToParent = new Dictionary<int, Parent>();
            IdToChild = new Dictionary<int, Child>();
        }

        public void InsertParent(Parent parent) {
            var command = new SQLiteCommand("insert into Parent (Id) values (" + parent.Id + ");", Connection);
            command.ExecuteNonQuery();
        }

        public void InsertChild(Child child) {
            var command = new SQLiteCommand(
                "insert into Child (Id, ParentId) values (" + child.Id + ',' + child.Parent.Id + ");", Connection);
            command.ExecuteNonQuery();
        }

        public Parent ParentFromId(int id) {
            if (IdToParent.ContainsKey(id))
                return IdToParent[id];

            var command = new SQLiteCommand("select * from Parent", Connection);
            var reader = command.ExecuteReader();
            Parent parent = null;

            while (reader.Read()) {
                var someId = (int) reader["Id"];

                if (someId != id) continue;
                parent = new Parent(someId);
                break;
            }

            IdToParent[id] = parent;
            return parent;
        }

        public Child ChildFromId(int id) {
            if (IdToChild.ContainsKey(id))
                return IdToChild[id];

            SQLiteCommand command = new SQLiteCommand("select * from Child", Connection);
            SQLiteDataReader reader = command.ExecuteReader();
            Child child = null;

            while (reader.Read()) {
                var someId = (int) reader["Id"];

                if (someId != id) continue;
                child = new Child(someId, ParentFromId((int) reader["ParentId"]));
                break;
            }

            IdToChild[id] = child;
            return child;
        }
    }
}