using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Contoso.Models.Entities.Base
{
   public abstract class EntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Aca comprende que la propiedad id es mi llave
        public int Id { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
