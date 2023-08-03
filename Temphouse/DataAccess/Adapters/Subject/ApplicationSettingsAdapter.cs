using Temphouse.DataAccess.Adapters.Abstract;

namespace Temphouse.DataAccess.Adapters.Subject
{
    public class ApplicationSettingsAdapter : AbstractAdapter
    {
        #region static Instance

        /// <summary>
        /// Статический экземпляр объекта.
        /// </summary>
        public static ApplicationSettingsAdapter Instance { get; private set; }

        static ApplicationSettingsAdapter()
        {
            Instance = new ApplicationSettingsAdapter();
        }

        #endregion


    }
}
