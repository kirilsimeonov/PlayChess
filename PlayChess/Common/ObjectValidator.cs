using System;
using System.Collections.Generic;
using System.Text;

namespace PlayChess.Common
{
    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(object obj, string errorMessage = Constants.EmptyString)
        {
            if (obj==null)
            {
                throw new NullReferenceException(ErrorMessages.NullPieceError);
            }
        }
    }
}
