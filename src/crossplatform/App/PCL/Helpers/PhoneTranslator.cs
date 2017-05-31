using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCL.Helpers
{
    public class PhoneTranslator
    {
        string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Numbers = "22233344455566677778889999";

        public string ToNumber(string alfanumericPhoneNumber)
        {
            var numPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alfanumericPhoneNumber))
            {
                alfanumericPhoneNumber = alfanumericPhoneNumber.ToUpper();
                foreach (var c in alfanumericPhoneNumber)
                {
                    if ("0123456789".Contains(c))
                    {
                        numPhoneNumber.Append(c);
                    }
                    else
                    {
                        var index = Letters.IndexOf(c);
                        if (index >= 0)
                        {
                            numPhoneNumber.Append(Numbers[index]);
                        }
                    }
                }
            }
            return numPhoneNumber.ToString();
        }
    }
}
