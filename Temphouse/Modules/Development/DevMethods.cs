using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temphouse.Models;

namespace Temphouse.Modules.Depelopment
{
    /// <summary>
    /// Под конец разработки этого метода остаться не должно. 
    /// </summary>
    public static class DevMethods
    {
        public static ObservableCollection<AuthorizedUserModel> GenerateBlankedAuthorizedUserModel(int count) 
        {
            ObservableCollection<AuthorizedUserModel> authorizedUserModels = new ObservableCollection<AuthorizedUserModel>();

            SessionModel session = new SessionModel();
            UserWithoutPasswordModel userWithoutPassword = new UserWithoutPasswordModel();

            for (int i = 0; i < count; i++) 
            {
                authorizedUserModels.Add(new AuthorizedUserModel(session, userWithoutPassword));
            }

            return authorizedUserModels;
        }

    }
}
