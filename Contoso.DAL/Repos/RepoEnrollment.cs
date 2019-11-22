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
    public class RepoEnrollment : RepoBase<Enrollment>, IRepoEnrollment
    {
        /*3 Creacion de constructores*/
        public RepoEnrollment()
        {

        }
        /*Daba error pero era porque la clase RepoBase carecia del constructor que traia el contextoContoso*/
        public RepoEnrollment(DbContextOptions<ContosoContext> options) : base(options)
        {

        }
    }
}
