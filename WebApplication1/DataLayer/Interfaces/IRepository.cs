﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
    }
}
