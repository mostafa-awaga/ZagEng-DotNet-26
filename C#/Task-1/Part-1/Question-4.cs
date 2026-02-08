using System;
namespace TaskOne
{
    //Question 4
    class User
    {
        public string Name;
    }
    struct UserSnapshot
    {
        public string Name;
    }

    class Program
    {
        static void Modify(User u, UserSnapshot us)
        {
            u.Name = "Modified User";
            us.Name = "Modified UserSnapshot";
        }

        static void ModifyRef(ref User u, ref UserSnapshot us)
        {
            u = new User { Name = "New User" };
            us = new UserSnapshot { Name = "New UserSnapshot" };

        }

        static void Main(string[] args)
        {
            User user = new User { Name = "Original User" };
            UserSnapshot snap = new UserSnapshot { Name = "Original UserSnapshot" };

            Modify(user, snap);

            Console.WriteLine(user.Name); // without ref, can change internal data but not the reference itself
            Console.WriteLine(snap.Name); // without ref, any change will be only on the copy of the struct, not the original

            ModifyRef(ref user, ref snap);

            Console.WriteLine(user.Name); // with ref, can change the reference itself, so it will point to a new object
            Console.WriteLine(snap.Name); // with ref, can change the struct itself, so it will update the original struct

            // Class User -> Reference Type -> Heap
            // Struct -> Value Type -> Stack
        }
    }
}