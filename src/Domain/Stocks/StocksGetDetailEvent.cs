using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace Domain.Stocks;
public sealed record StocksGetDetailEvent(string stock) : IDomainEvent;
