﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFM.Fundation.SimpleMediator.Interface;

public interface IValidator<TRequest>
{
    Task ValidateAsync(TRequest request, CancellationToken cancellationToken);
}
