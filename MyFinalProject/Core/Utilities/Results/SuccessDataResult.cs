using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data, true, message)  //istersen data ve mesaj ver
        {
            
        }
        public SuccessDataResult(T data) : base(data, true) //istersen sadece data ver 
        {

        }
        //don`t look
        public SuccessDataResult(string message):base(default,true, message)  //istersen sadece mesaj ver //default gelen data neyse aynen geri ver 2:30:00 10.gün
        {
                        
        }

        public SuccessDataResult() : base(default, true) //istersen hiç bir şey verme
        {

        }
    }
}
