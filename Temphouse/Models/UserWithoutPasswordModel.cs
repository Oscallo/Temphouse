namespace Temphouse.Models
{
    public class UserWithoutPasswordModel : UserModel
    {
        public new string Password = string.Empty;

        public UserWithoutPasswordModel() : base() { }
    }
}
