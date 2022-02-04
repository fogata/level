﻿using System;
using System.Collections.Generic;

namespace Level.Domain.Entities
{
    public class Cart
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public int articleitemId { get; set; }
        public ICollection<ArticleItem> items { get; set; }
    }
}
