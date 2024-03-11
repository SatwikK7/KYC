using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYC
{
    static internal class CyberSecurity
    {
        static public bool CheckSQLInjection(string input)
        {
            string[] sqlKeywords = { "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "TABLE", "FROM", "WHERE" };
            foreach (var keyword in sqlKeywords)
            {
                if (input.ToUpper().Contains(keyword))
                {
                    return false; 
                }
            }
            return true; 
        }

    }
}
