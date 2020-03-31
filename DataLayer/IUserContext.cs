using ModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IUserContext
    {
        User GetById(int? id);
    }
}
