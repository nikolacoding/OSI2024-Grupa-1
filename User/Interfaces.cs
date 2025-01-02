using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User {
    public class Interfaces {
        public interface IInitializable {
            public void SetDefaultWindowSettings();
            public void FillStaticConstants();
            public void SetDefaultStates();
        }
    }
}
