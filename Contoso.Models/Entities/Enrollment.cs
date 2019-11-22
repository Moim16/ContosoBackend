using Contoso.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.Models.Entities
{
    //Enum Tipo de Dato Primitivo, valores dificil van a cambiar
    public enum Grade// Sirve para definir valores amarrados, algo que esta definido, permite evitar errores de dedos, los unicos valores que aceptara grade son los que estan abajo
    {
        A,B,C,D,E,F
    }
    public class Enrollment : EntityBase
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }// Al poner Student indica que es la llave foranea Clase--ID asi lo reconoce si pone coursenumero lo pone como propiedad de Enrollment , si se quier poner otra se pone foreig key
        public Grade? Nota { get; set; }
        /*Propiedades de Navegacion se tienen que poner a huevo*/
        public Course Course { get; set; }//Relacion de 1
        public Student Student { get; set; }//Relacion de 1
    }
}
