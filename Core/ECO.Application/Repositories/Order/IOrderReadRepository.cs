﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories.Order
{
    public interface IOrderReadRepository : IReadRepository<Domain.Entities.Order, int>
    {
    }
}
