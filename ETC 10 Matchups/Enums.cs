using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ETC10Matchups
{
    public enum MatchupStrength
    {
        Unknown,
        Good,
        Average,
        Bad
    }

    public enum Races
    {
        Beasts,
        Bretonnians,

        [Description("Chaos Dwarves")]
        ChaosDwarves,
        Daemons,

        [Description("Dark Elves")]
        DarkElves,

        [Description("Dogs of War")]
        DOW,
        Dwarves,
        Empire,

        [Description("High Elves")]
        HighElves,
        Lizardmen,
        Ogres,

        [Description("Orcs & Goblins")]
        Orcs,
        Skaven,

        [Description("Tomb Kings")]
        TombKings,
        Vampires,

        [Description("Warriors of Chaos")]
        Warriors,

        [Description("Wood Elves")]
        WoodElves
    }

    /// <summary>
    /// Class with enum parsing functionality
    /// </summary>
    public static class EnumParser
    {
        /// <summary>
        /// Gets the description text of an enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>																	 
        public static string GetDescription(Enum value)
        {
            return GetEnumAttributeDescription<DescriptionAttribute>(value);
        }

        /// <summary>
        /// Gets the description text of an enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>																	 
        public static Attribute GetEnumAttribute<T>(Enum value) where T : Attribute
        {
            string description = value.ToString();

            FieldInfo fi = value.GetType().GetField(description);
            if (fi != null)
            {
                //Get all attributes of the given type on this particular enum value
                T[] attributes = (T[])fi.GetCustomAttributes(typeof(T), false);
                if (attributes.Length > 0)
                {
                    return attributes[0];
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the description text of an enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>																	 
        public static string GetEnumAttributeDescription<T>(Enum value) where T : Attribute
        {
            T attribute = (T)GetEnumAttribute<T>(value);

            if (attribute == null)
                return value.ToString();
            else
            {
                //Get the description property of this attribute
                Type attributeType = typeof(T);
                PropertyInfo propertyInfo = attributeType.GetProperty("Description");

                return (string)propertyInfo.GetValue(attribute, null);
            }
        }
    }
}
