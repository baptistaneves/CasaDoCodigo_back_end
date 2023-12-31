﻿namespace CasaDoCodigo.Domain.DomainObjects.Commands;

public class Command<T> : IRequest<T>
{
    public ValidationResult ValidationResult { get; set; }

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}
