using CoreLand.UI.MVVM.Models;
using Temphouse.DataAccess.Adapters;

namespace Temphouse.MVVM.Models
{
    public class AuthorizedUserModel : BaseModel
    {
        private SessionModel _session;
        private UserWithoutPasswordModel _userWithoutPassword;

        public SessionModel Session
        {
            get => _session;
            set
            {
                SetValue(ref _session, value);
            }
        }

        public UserWithoutPasswordModel UserWithoutPasswordModel
        {
            get => _userWithoutPassword;
            set
            {
                SetValue(ref _userWithoutPassword, value);
            }
        }

        public AuthorizedUserModel(SessionModel session, UserWithoutPasswordModel userWithoutPassword)
        {
            UserWithoutPasswordModel = userWithoutPassword;
            Session = session;
        }

        public AuthorizedUserModel(SessionModel session) : this(session, DataBaseAdapterBuilder.Instance.GetUserBySession(session)) { }

        public AuthorizedUserModel(SessionModel session, UserModel user) : this(session, (UserWithoutPasswordModel)user) { }
    }
}
