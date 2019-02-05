/*
  Interface: IEncryptable.cs
  Author:    Arpit Patel
  Date:      November 06, 2018

  Purpose: This interface has two methods that classes making use of must
           implement. 

           This code is not to be altered.
*/

/// <summary>
/// The class implementing the Encrypt() method will use some sort
/// of encryption algorithm to return some encrypted data.
///
///  The class implementing the Decrypt() method will use (presumably)
///  the same encryption algorithm to return a decrypted string.
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public interface IEncryptable
    {
        string Encrypt();
        string Decrypt();
    }
}
