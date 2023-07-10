namespace Temphouse.Models
{
    public class UserWithoutPasswordModel : UserModel
    {
        public new string Password = string.Empty;

        public UserWithoutPasswordModel() : base() { }

        public UserWithoutPasswordModel(string name, string family, string password) : base(name, family, password) { }
    }
}
