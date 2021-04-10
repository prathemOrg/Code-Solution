using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSolutionDataLayer
{
    class Class1
    {
       static void Main()
        {
            DataManager dm = new DataManager();
            /* User u = new User();
             u.UserFirstName = "vijay";
             u.UserLastName = "amni";
             u.UserEmail = "va.va@gmail.com";
             u.UserPassword = "1234";
             dm.AddUser(u);
             */
            foreach (User user in dm.GetAllUsers())
            {
                Console.WriteLine(user.UserFirstName);
               
            }
           // dm.DeleteUser(1);
            Console.ReadLine();
        }
        
    }
}
