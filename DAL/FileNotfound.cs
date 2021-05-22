using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  

        [Serializable]
        public class FileNotfound : Exception
        {
            public FileNotfound() { }
            public FileNotfound(string message) : base(message) { }
            public FileNotfound(string message, Exception inner) : base(message, inner) { }
            protected FileNotfound(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }

