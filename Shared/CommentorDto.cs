﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharpScape.Shared.Dto
{
    public class CommentorInfoDto
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string DateFormat { get; set; }
    }
}