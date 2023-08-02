using System;

namespace CoreLand.UI.Attributes.Enum
{
    public class NameAttribute : Attribute
    {
        public string Name { get; private set; }

        public NameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
