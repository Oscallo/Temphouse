using Temphouse.MVVM.Models;

namespace Temphouse.Extensions.Models
{
    public static class SessionModelExtensions
    {
        public static string ToStringCollectionElement(this SessionModel sessionModel)
        {
            return sessionModel.ToString();
        }
    }
}
