using System;
using System.Text.Json;

namespace SV_backend.Domain.Models;

public class ErrorDetalhe
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Trace {get; set;}

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
