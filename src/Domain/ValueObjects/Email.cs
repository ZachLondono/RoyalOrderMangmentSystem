using RoyalOrderManager.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace RoyalOrderManager.Domain.ValueObjects;

internal class Email : ValueOf<string, Email> {

    protected override void Validate() {

        string[] parts = Value.Split("@");

        if (parts.Length != 2)
            throw new InvalidEmailException(Value);

    }

}
