using System;
using System.Collections.Generic;
using System.Text;

namespace ETC10Matchups
{
    [AttributeUsage(AttributeTargets.Field)]
    public class HasSubTypesAttribute : System.Attribute
    {
        /// <summary>
        /// This indicates that this army has other detailed types of armies against it
        /// </summary>
        public HasSubTypesAttribute()
        { }
    }
}
