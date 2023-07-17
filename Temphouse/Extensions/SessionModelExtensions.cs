using Temphouse.Models;

namespace Temphouse.Extensions
{
    public static class SessionModelExtensions
    {
        public static string ToStringCollectionElement(this SessionModel sessionModel)
        {
            return sessionModel.ToString();
        }
    }
}
