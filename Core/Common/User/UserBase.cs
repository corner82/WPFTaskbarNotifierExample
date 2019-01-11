using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.User
{
    public class UserBase : IUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SicilNo { get; set; }


        public UserBase()
        {

        }
    }
}
