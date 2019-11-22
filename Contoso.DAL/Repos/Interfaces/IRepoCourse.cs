using System;
using System.Collections.Generic;
using System.Text;

/*Se crean estos using*/
using Contoso.DAL.Repos.Base;
using Contoso.Models.Entities;
namespace Contoso.DAL.Repos.Interfaces
{
    public interface IRepoCourse : IRepoBase<Course>
    {

    }
}
