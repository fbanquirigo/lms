using SaG.Business.Models;

namespace SaG.Services
{
    public static class TouchKeyPosExtensions
    {
        public static int Position(this TouchKeyPos tkPos, int commandId)
        {
            if (tkPos.CmdId0 != null && tkPos.CmdId0.CmdId == commandId)
                return 0;
            if (tkPos.CmdId1 != null && tkPos.CmdId1.CmdId == commandId)
                return 1;
            if (tkPos.CmdId2 != null && tkPos.CmdId2.CmdId == commandId)
                return 2;
            if (tkPos.CmdId3 != null && tkPos.CmdId3.CmdId == commandId)
                return 3;
            return -1;
        }
    }
}
