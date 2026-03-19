using System;
using System.Collections.Generic;

namespace FM.Domain.Entities;

public partial class EncryptionKey
{
    public decimal Keyid { get; set; }

    public byte[]? Secretkey { get; set; }
}
