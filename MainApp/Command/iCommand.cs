using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    //Command
    interface iCommand
    {
        void Execute();
    }

    class UpdateOffCommand : iCommand
    {
        Casino casino;

        public UpdateOffCommand(Casino casino)
        {
            this.casino = casino;
        }

        public void Execute()
        {
            casino.UpdateOff();
        }
    }

    class UpdateOnCommand : iCommand
    {
        Casino casino;

        public UpdateOnCommand(Casino casino)
        {
            this.casino = casino;
        }

        public void Execute()
        {
            casino.UpdateOn();
        }
    }
}
