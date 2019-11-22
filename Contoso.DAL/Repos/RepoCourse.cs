using System;
using System.Collections.Generic;
using System.Text;

/*1 Se crean using*/
using Contoso.DAL.Repos.Base;
using Contoso.DAL.Repos.Interfaces;
using Contoso.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Contoso.DAL.EF;

namespace Contoso.DAL.Repos
{
    /*2iMPLEMENTA todos los metodos de la interfaz IReporCourse y hereda de clase RepoBase*/
    public class RepoCourse : RepoBase<Course>, IRepoCourse
    {

        /*3 Creacion de constructores*/
        public RepoCourse()
        {

        }
        /*Daba error pero era porque la clase RepoBase carecia del constructor que traia el contextoContoso*/
        public RepoCourse(DbContextOptions<ContosoContext> options) : base(options)
        {

        }
    }
}
