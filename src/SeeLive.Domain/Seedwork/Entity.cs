using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeeLive.Domain
{
  public abstract class Entity
    { 
        int _Id;        
        public virtual int Id 
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }
    }
}
