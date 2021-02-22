using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)  //istersen data ve mesaj ver
        {

        }
        public ErrorDataResult(T data) : base(data, false) //istersen sadece data ver 
        {

        }
        //don`t look
        public ErrorDataResult(string message) : base(default, false, message)  //istersen sadece mesaj ver //default gelen data neyse aynen geri ver 2:30:00 10.gün
        {

        }

        public ErrorDataResult() : base(default, false) //istersen hiç bir şey verme
        {

        }
    }
}
