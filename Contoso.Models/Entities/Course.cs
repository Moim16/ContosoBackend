using Contoso.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Models.Entities
{
    public class Course:EntityBase
    {
        public string Titulo { get; set; }
        public int Creditos { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
