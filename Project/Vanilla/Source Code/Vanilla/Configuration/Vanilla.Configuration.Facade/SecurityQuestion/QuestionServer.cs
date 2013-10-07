using System;
using System.Collections.Generic;
using Crystal.Guardian.Component.SecurityQuestion;


namespace Vanilla.Configuration.Facade.SecurityQuestion
{

    public class QuestionServer : IQuestion
    {

        #region IQuestion

        BinAff.Core.ReturnObject<FormDto> IQuestion.LoadForm()
        {
            BinAff.Core.ICrud crud = new Server(null);
            BinAff.Core.ReturnObject<List<BinAff.Core.Data>> dataList = crud.ReadAll();
            BinAff.Core.ReturnObject<FormDto> ret = new BinAff.Core.ReturnObject<FormDto>
            {
                Value = new FormDto
                {
                    QuestionList = new List<Dto>()
                }
            };

            //Populate data in dto from business entity
            foreach (Data data in dataList.Value)
            {
                ret.Value.QuestionList.Add(new Dto
                {
                    Id = data.Id,
                    Question = data.Question
                });
            }

            return ret;
        }

        BinAff.Core.ReturnObject<Boolean> IQuestion.Add(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Question = dto.Question
            });
            return crud.Save();
        }

        BinAff.Core.ReturnObject<Boolean> IQuestion.Delete(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Id = dto.Id
            });
            return crud.Delete();
        }

        BinAff.Core.ReturnObject<Dto> IQuestion.Read(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Id = dto.Id
            });
            BinAff.Core.ReturnObject<BinAff.Core.Data> data = crud.Read();
            return new BinAff.Core.ReturnObject<Dto>
            {
                Value = new Dto
                {
                    Id = data.Value.Id,
                    Question = ((Data)data.Value).Question,
                }
            };
        }

        BinAff.Core.ReturnObject<Boolean> IQuestion.Change(Dto dto)
        {
            BinAff.Core.ICrud crud = new Server(new Data
            {
                Id = dto.Id,
                Question = dto.Question
            });
            return crud.Save();
        }

        #endregion

    }

}
