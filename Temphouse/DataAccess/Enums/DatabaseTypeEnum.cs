using CoreLand.UI.Attributes.Enum;
using System.ComponentModel;

namespace Temphouse.DataAccess.Enums
{
    public enum DatabaseTypeEnum
    {
        [Browsable(false)]
        [Name("Соединение отсутствует")]
        None = 0,

        [Browsable(true)]
        [Name("Файловая БД")]
        File = 1,

        [Browsable(true)]
        [Name("Сетевая БД")]
        Service = 2
    }
}
