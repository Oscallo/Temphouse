using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temphouse.Models
{
    public class UserBaseModel
    {
        public UserBaseModel() { }
    }

    public class UserModel : UserBaseModel
    {
        public UserModel() : base() { }
    }

    public class UserWithoutPasswordModel : UserBaseModel
    {
        public UserWithoutPasswordModel() : base() { }
    }
}
