using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temphouse.MVVM.Models;

namespace Temphouse.Development
{
    /// <summary>
    /// Под конец разработки этого метода остаться не должно. 
    /// </summary>
    public static class DevMethods
    {
        internal static ObservableCollection<AuthorizedUserModel> GenerateBlankedAuthorizedUserModel(int count)
        {
            ObservableCollection<AuthorizedUserModel> authorizedUserModels = new ObservableCollection<AuthorizedUserModel>();

            SessionModel session = new SessionModel(0);
            UserWithoutPasswordModel userWithoutPassword = new UserWithoutPasswordModel(GenerateRandomString(4), GenerateRandomString(3));

            for (int i = 0; i < count; i++)
            {
                authorizedUserModels.Add(new AuthorizedUserModel(session, userWithoutPassword));
            }

            return authorizedUserModels;
        }

        internal static string GenerateRandomString(int length)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            const string allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string rezult = new string(Enumerable.Repeat(allChars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            return rezult;
        }
    }
}
