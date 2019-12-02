﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SqlliteApp.Standard.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entity);

        void Delete(TEntity entity);
        void Save();


    }
}
