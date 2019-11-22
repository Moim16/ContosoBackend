using Contoso.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Models.Entities
{
   public class Student:EntityBase
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
