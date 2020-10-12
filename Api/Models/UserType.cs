using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        /// <summary>
        /// The user type id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user type desctiption
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The user type code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The list of users
        /// </summary>
        public virtual ICollection<User> User { get; set; }
    }
}
