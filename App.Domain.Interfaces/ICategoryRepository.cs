﻿using App.Domain.Entities;
using App.Domain.Interfaces.Framework;

namespace App.Domain.Interfaces
{
    public interface ICategoryRepository : IReadonlyRespository<int, Category>
    {
    }
}
