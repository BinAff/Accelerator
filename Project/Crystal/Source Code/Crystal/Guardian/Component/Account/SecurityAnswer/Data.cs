using System;

namespace Crystal.Guardian.Component.Account.SecurityAnswer
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Security question
        /// </summary>
        public SecurityQuestion.Data Question { get; set; }

        /// <summary>
        /// Answer of security question
        /// </summary>
        public String Answer { get; set; }

    }

}
