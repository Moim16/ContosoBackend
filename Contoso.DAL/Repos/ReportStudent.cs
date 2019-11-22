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

    /*2iMPLEMENTA todos los metodos de la interfaz IReportStudent y hereda de clase RepoBase*/
    public class ReportStudent : RepoBase<Student>, IReportStudent
    {
        /*3 Creacion de constructores*/
        public ReportStudent()
        {

        }
        /*Daba error pero era porque la clase RepoBase carecia del constructor que traia el contextoContoso*/
        public ReportStudent(DbContextOptions<ContosoContext> options):base(options)
        {


        }

    }
}
