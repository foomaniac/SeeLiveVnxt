using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeeLive.Core.Domain
{
  public interface IEntity<TKey>
    { 
        public TKey Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }

        public string CreatedByUser { get; set; }
    }
}
