
using Api.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Api.DTO
{
    public class UserDto
    {
        /// <summary>
        /// The user id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// The user surname
        /// </summary>
        [StringLength(20)]
        public string Surname { get; set; }

        /// <summary>
        /// The user birth date
        /// </summary>
        public DateTime BirthDate { get; set; }


        /// <summary>
        /// The user type id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than {1}")]
        public int UserTypeId { get; set; }

        /// <summary>
        /// The user title id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than {1}")]
        public int UserTitleId { get; set; }

        /// <summary>
        /// The user title object
        /// </summary>
        public UserTitleDto UserTitle { get; set; }

        /// <summary>
        /// The user type object
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// The user email address
        /// </summary>
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Determines if user s active
        /// </summary>
        public bool IsActive { get; set; }
    }
}
