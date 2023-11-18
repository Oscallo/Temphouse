using System.Security;

namespace Temphouse.MVVM.Models
{
    public class UserWithoutPasswordModel : UserModel
    {
        public new string Password = string.Empty;

        public UserWithoutPasswordModel() : base() { }

        public UserWithoutPasswordModel(string name, string family) : base(name, family, null) { }
    }
}
