using CoreLand.UI.ViewModels;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Temphouse.Adapters;
using Temphouse.Models;

namespace Temphouse.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private ObservableCollection<AuthorizedUserModel> _Users = new ObservableCollection<AuthorizedUserModel>();

        public ObservableCollection<AuthorizedUserModel> Users 
        {
            get { return _Users; }
            private set 
            {
                if (value == _Users) { return; }
                OnPropertyChanging(nameof(Users));
                _Users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public void AddUser(AuthorizedUserModel user) 
        {
            Users.Add(user);
        }

        public void AddUser(SessionModel session)
        {
            AddUser(new AuthorizedUserModel(session));
        }

        public async void AddUserAsync(AuthorizedUserModel user)
        {
            await Task.Run(() => AddUser(user));
        }

        public async void AddUserAsync(SessionModel session)
        {
            await Task.Run(() => AddUserAsync(session));
        }

        public void RemoveUser(AuthorizedUserModel user)
        {
            Users.Remove(user);
        }

        public void RemoveUser(SessionModel session)
        {
            var userWithSessions = Users.Where(x => x.Session == session).First();

            if (userWithSessions != null) 
            {
                RemoveUser(userWithSessions);
            }

        }

        public async void RemoveUserAsync(AuthorizedUserModel user)
        {
            await Task.Run(() => RemoveUser(user));
        }

        public async void RemoveUserAsync(SessionModel session)
        {
            await Task.Run(() => RemoveUserAsync(session));
        }

        public UsersViewModel() 
        {
            SessionModel session = new SessionModel();
            UserWithoutPasswordModel userWithoutPassword = new UserWithoutPasswordModel();
            /// Представление данных для дизайнера
            AddUser(new AuthorizedUserModel(session,userWithoutPassword));
            AddUser(new AuthorizedUserModel(session, userWithoutPassword));
            AddUser(new AuthorizedUserModel(session, userWithoutPassword));
        }

        public UsersViewModel(IList<SessionModel> sessions) 
        {
            foreach (var session in sessions) 
            {
                AddUserAsync(session);
            }
        }
    }
}
