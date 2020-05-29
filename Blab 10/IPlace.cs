using System;
using System.Collections.Generic;
using System.Text;

namespace Blab_10
{
    public interface IPlace
    {
        public void InputCreate();

        public void RandomCreate();

        public void Show();

        public bool Search(object search);
    }
}
