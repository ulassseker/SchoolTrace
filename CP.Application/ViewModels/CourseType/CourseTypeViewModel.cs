﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Application.ViewModels.CourseType
{
    public class CourseTypeViewModel
    {
        public Guid CourseTypeId { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
