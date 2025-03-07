﻿namespace Bookify.Domain.Shared;

public record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money first, Money second)
    {
        if (first.Currency != second.Currency)
        {
            throw new InvalidOperationException("Currencies must be equal");
        }

        return new Money(first.Amount + second.Amount, first.Currency);
    }

    public static Money Zero()
    {
        return new(0, Currency.None);
    }

    public static Money Zero(Currency currency)
    {
        return new(0, currency);
    }

    public bool IsZero() => this == Zero();
}
