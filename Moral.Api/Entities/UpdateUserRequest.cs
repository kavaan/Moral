﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets the user's given name
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's surname
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's surname
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        [MaxLength(255)]
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
