using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.DTOs.Responses;

public record GetSentimentDto(string sentiment, string insight);
