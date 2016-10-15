using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingUtility
{
    public static class NullGuard
    {
        public static void ThrowIfNull(params object[] argumentValues)
        {

            if(argumentValues == null)
                throw new ArgumentNullException();

            foreach (object obj in argumentValues)
            {
                if (obj == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public static bool FalseIfNull(params object[] argumentValues)
        {
            if (argumentValues == null)
                return false;

            foreach (object obj in argumentValues)
            {
                if (obj == null)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
