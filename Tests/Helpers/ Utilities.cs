using UserInfoApp.Model.Context;

namespace Tests
{

    public static class Utilities
    {
    // <snippet1>
        public static void InitializeDbForTests(MainContext db)
        {
        // TODO:
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(MainContext db)
        {
            // TODO
            InitializeDbForTests(db);
        }
    
    // </snippet1>
    }
}