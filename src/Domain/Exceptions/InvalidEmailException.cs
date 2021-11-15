using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalOrderManager.Domain.Exceptions;

public class InvalidEmailException : Exception {
    public InvalidEmailException(string value) : base($"Email format is not valid: '{value}'")
    { }
}
