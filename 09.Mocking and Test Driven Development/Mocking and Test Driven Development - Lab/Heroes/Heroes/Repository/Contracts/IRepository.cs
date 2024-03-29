﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repository.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void AddItem(T model);

        T FindByName(string name);

        bool RemoveItem(string name);
    }
}
