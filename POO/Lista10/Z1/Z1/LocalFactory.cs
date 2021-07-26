using System;

namespace Z1 {
    public class LocalFactory {
        public static Func<Orm> OrmProvider { get; set; }

        public static Orm CreateORM() {
            if (OrmProvider == null)
                throw new Exception("NULL Provider");

            return OrmProvider();
        }
    }
}