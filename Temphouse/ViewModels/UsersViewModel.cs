using CoreLand.UI.ViewModels;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Temphouse.Adapters;
using Temphouse.Models;

namespace Temphouse.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private ObservableCollection<UserWithoutPasswordModel> _Users = new ObservableCollection<UserWithoutPasswordModel>();

        public ObservableCollection<UserWithoutPasswordModel> Users 
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

        public void AddUser(UserWithoutPasswordModel user) 
        {
            Users.Add(user);
        }

        public void AddUser(SessionModel session)
        {
            UserModel user = DataBaseAdapter.GetUserBySession(session);

            AddUser((UserWithoutPasswordModel)user);
        }

        public async void AddUserAsync(UserWithoutPasswordModel user)
        {
            await Task.Run(() => AddUser(user));
        }

        public async void AddUserAsync(SessionModel session)
        {
            await Task.Run(() => AddUserAsync(session));
        }

        public void RemoveUser(UserWithoutPasswordModel user)
        {
            Users.Remove(user);
        }

        public void RemoveUser(SessionModel session)
        {
            UserModel user = DataBaseAdapter.GetUserBySession(session);

            RemoveUser((UserWithoutPasswordModel)user);
        }

        public async void RemoveUserAsync(UserWithoutPasswordModel user)
        {
            await Task.Run(() => RemoveUser(user));
        }

        public async void RemoveUserAsync(SessionModel session)
        {
            await Task.Run(() => RemoveUserAsync(session));
        }

        public UsersViewModel() 
        {
            /// Представление данных для дизайнера
            AddUser(new UserWithoutPasswordModel());
            AddUser(new UserWithoutPasswordModel());
            AddUser(new UserWithoutPasswordModel());
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
