using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;

namespace WebUI.Models
{
    public class CommonArticleModel
    {
        public IEnumerable<ArticleModel> Articles { get; set; } 
        public string BlogName { get; set; }
        public string UserName { get; set; }
    }

    public class ArticleModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public IEnumerable<BllTagEntity> Tags { get; set; }
    }
}