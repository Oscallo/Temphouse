﻿using CoreLand.UI.Modules.Commands;
using CoreLand.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Temphouse.Adapters;
using Temphouse.Models;

namespace Temphouse.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ICommand SetSessionCommand { get; private set; }
        public ICommand RemoveSessionCommand { get; private set; }

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

        public UsersViewModel() 
        {
            this.SetSessionCommand = new RelayCommand(new Action<object>(_SetSesion));
            this.RemoveSessionCommand = new RelayCommand(new Action<object>(_RemoveSession));

            /// Это необходимо будет, когда сессии будут подгружаться с адаптера
            /// Users = ApplicationSettingsAdapter.Instance.Sessions;


            /// Представление данных для дизайнера
            SessionModel session = new SessionModel();
            UserWithoutPasswordModel userWithoutPassword = new UserWithoutPasswordModel();

            AddUser(new AuthorizedUserModel(session, userWithoutPassword));
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

        private void _RemoveSession(object sessionModel)
        {
            RemoveUser((SessionModel)sessionModel);
        }

        private void _SetSesion(object sessionModel)
        {
            throw new NotImplementedException();
        }
    }
}