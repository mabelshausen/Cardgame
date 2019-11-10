using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Lib.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        private DateTime? createdDateTime;

        public DateTime? CreatedDateTime
        {
            get
            {
                return createdDateTime ?? DateTime.Now;
            }
            set
            {
                if (value != null)
                {
                    createdDateTime = value;
                }
                else
                {
                    createdDateTime = DateTime.Now;
                }
            }
        }
    }
}
