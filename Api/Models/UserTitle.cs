using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class UserTitle
    {
        public UserTitle()
        {
            User = new HashSet<User>();
        }

        /// <summary>
        /// The user title id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user Description
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// The list of users
        /// </summary>
        public virtual ICollection<User> User { get; set; }
    }
}
