using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class ArticleDTO
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string MovieType { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string YoutubeUrl { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastReplyTime { get; set; }
        public string StrCreateTime { get; set; } //for顯示用
        public string StrLastReplyTime { get; set; }//for顯示用
    }
}
