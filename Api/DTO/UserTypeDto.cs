﻿using System.ComponentModel.DataAnnotations;

namespace Api.DTO
{
    public class UserTypeDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }
}
