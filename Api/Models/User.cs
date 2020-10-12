using System;

namespace Api.Models
{
    public partial class User
    {
        /// <summary>
        /// The user id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// The user birth date
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// The user type id
        /// </summary>
        public int UserTypeId { get; set; }

        /// <summary>
        /// The user title id
        /// </summary>
        public int UserTitleId { get; set; }

        /// <summary>
        /// The user email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Determines if user s active
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// The user title object
        /// </summary>
        public virtual UserTitle UserTitle { get; set; }

        /// <summary>
        /// The user type object
        /// </summary>
        public virtual UserType UserType { get; set; }
    }
}
