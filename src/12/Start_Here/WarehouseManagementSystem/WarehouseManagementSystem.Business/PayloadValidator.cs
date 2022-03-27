using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Business
{
    public class PayloadValidator
    {
        public bool Validate(ReadOnlySpan<byte> payload)
        {
            var signature = payload[^128..];
            
            foreach(var piece in signature)
            {
                if(piece == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
