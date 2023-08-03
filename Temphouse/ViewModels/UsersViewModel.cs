using CoreLand.UI.CustomControls.Windows;
using CoreLand.UI.Modules.Commands;
using CoreLand.UI.MVVM.ViewModels;
using CoreLand.UI.Extensions.Standart.CollectionExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Temphouse.Models;
using Temphouse.Modules.Adapters;
using Temphouse.Windows;

namespace Temphouse.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ICommand SetSessionCommand { get; private set; }
        public ICommand RemoveSessionCommand { get; private set; }

        public ExtendedWindow LoginWindow { get; set; }

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

            /// Это необходимо будет, когда сессии будут подгружаться с адаптера
            /// ApplicationSettingsAdapter.Instance.RemoveSession(user.Session);
        }

        public void RemoveUser(SessionModel session)
        {
            var userWithSessions = Users.Where(x => x.Session == session).First();

            if (userWithSessions != null) 
            {
                RemoveUser(userWithSessions);
            }

            /// Это необходимо будет, когда сессии будут подгружаться с адаптера
            /// ApplicationSettingsAdapter.Instance.RemoveSession(session);
        }

        public async void RemoveUserAsync(AuthorizedUserModel user)
        {
            await Task.Run(() => RemoveUser(user));
        }

        public async void RemoveUserAsync(SessionModel session)
        {
            await Task.Run(() => RemoveUserAsync(session));
        }

        public UsersViewModel() : this(UserSettingsAdapter.Instance.Sessions.ToIList())
        {
            // Если нужно создать для тестирования
            //if (Users.Count == 0) 
            //{
            //    Users = DevMethods.GenerateBlankedAuthorizedUserModel(2);
            //}
        }

        private void _InitializeCommands() 
        {
            this.SetSessionCommand = new RelayCommand(new Action<object>(_SetSesion));
            this.RemoveSessionCommand = new RelayCommand(new Action<object>(_RemoveSession));
        }

        public UsersViewModel(IList<SessionModel> sessions) 
        {
            _InitializeCommands();

            foreach (var session in sessions) 
            {
                AddUserAsync(session);
            }
        }

        private void _RemoveSession(object sessionModel)
        {
            RemoveUser((SessionModel)sessionModel);
        }

        private void _SetSesion(object sessionModel)
        {
            bool sessionIsValid = false;
            DataBaseAdapterBuilder.Instance.UserAuthorization((SessionModel)sessionModel, out sessionIsValid);

            if (sessionIsValid == true) 
            {
                if (LoginWindow != null)
                {
                    new DashboardWindow((SessionModel)sessionModel).Show();
                    LoginWindow.Close();
                }
                else 
                {
                    throw new NullReferenceException("Не удалось найти окно, к которому привязан UserControl"); 
                }
            }
        }
    }
}
