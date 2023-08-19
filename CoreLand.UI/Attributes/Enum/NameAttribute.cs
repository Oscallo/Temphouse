using System;

namespace CoreLand.UI.Attributes.Enum
{
    /// <summary>
    /// ВНИМАНИЕ, для работы необходимо указывать уникальными для работы с <seealso cref="System.Enum"/>
    /// </summary>
    public class NameAttribute : Attribute
    {
        public string Name { get; private set; }

        public NameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
