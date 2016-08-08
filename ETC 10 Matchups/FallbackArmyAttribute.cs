using System;
using System.Collections.Generic;
using System.Text;

namespace ETC10Matchups
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FallbackArmyAttribute : System.Attribute
    {
        private string _description;

        /// <summary>
        /// Setting this Attribue against a enum will allow you 		
        /// to map a value to the enum ></see> property
        /// </summary>
        /// <param name="description"></param>
        public FallbackArmyAttribute(string description)
        {
            _description = description;
        }

        /// <summary>
        /// The name of the field being returned from the database
        /// </summary>
        public string Description
        {
            get { return _description; }
        }
    }
}
