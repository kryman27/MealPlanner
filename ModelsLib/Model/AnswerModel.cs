using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLib.Model
{
    public class AnswerModel<T>
    {
        public AnswerModel(T dataModel, string headerInfoValue)
        {
            DataModel = dataModel;
            HeaderInfoValue = headerInfoValue;
        }

        public T DataModel { get; set; }
        public string HeaderInfoValue { get; set; }
    }
}
