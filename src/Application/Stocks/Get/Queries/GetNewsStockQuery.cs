using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Stocks.Get.Responses;

namespace Application.Stocks.Get.Queries;
public sealed record GetNewsStockQuery(string stock): IQuery<List<GoogleNewsDtoResponse>>;
