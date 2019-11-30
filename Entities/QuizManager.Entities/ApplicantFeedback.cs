﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.Entities
{
   public class ApplicantFeedback:EntityBase
    {
        public string UserId { get; set; }
        public long TopicId { get; set; }
        public long QuestionId { get; set; }
        public string Feedback { get; set; }
    }
}
