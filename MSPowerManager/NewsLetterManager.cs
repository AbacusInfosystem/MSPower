﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class NewsLetterManager
    {

        public NewsLetterRepo _nlRepo = null;

         public NewsLetterManager()
        {
            _nlRepo = new NewsLetterRepo();
        }

        public List<NewsLetterInfo> Get_NewsLetters(ref PaginationInfo Pager)
        {
            return _nlRepo.Get_NewsLetters(ref Pager);
        }

        public NewsLetterInfo Get_NewsLetter_By_Id(int newsletter_Id)
        {
            return _nlRepo.Get_NewsLetter_By_Id(newsletter_Id);
        }

        public int Insert_NewsLetter(NewsLetterInfo newsletter)
        {
            return _nlRepo.Insert_NewsLetter(newsletter);
        }

        public void Update_NewsLetter(NewsLetterInfo newsletter)
        {
            _nlRepo.Update_NewsLetter(newsletter);
        }

    }
}