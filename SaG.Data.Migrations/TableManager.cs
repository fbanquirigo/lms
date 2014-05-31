using System.Collections.Generic;

namespace SaG.Data.Migrations
{
    sealed class TableManager
    {
        public static List<string> TABLES = new List<string>
            {
                "tblAccessor",
                "tblAlarms",
                "tblATMs",
                "tblAuditStatus",
                "tblBankModeStatus",
                "tblBankOperDescs",
                "tblBitActive",
                "tblBitYesNo",
                "tblCmds",
                "tblDispatchers",
                "tblDispATMs",
                "tblExceptionLimit",
                "tblLevel",
                "tblLinkOperIDs",
                "tblLinkSystem",
                "tblLockResult",
                "tblLocks",
                "tblOpCodeAudit",
                "tblOperationCodes",
                "tblOperators",
                "tblOperAudit",
                "tblOwners",
                "tblPendAuditStatus",
                "tblPendBackModeStatus",
                "tblPendTampResetStatus",
                "tblPrivileges",
                "tblResultDescs",
                "tblRouteATMs",
                "tblRouteDescs",
                "tblRptLockAudit",
                "tblRptTkUserAudit",
                "tblSystem",
                "tblTampResetStatus",
                "tblTouchKeyParms",
                "tblTouchKeyPos",
                "tblTouchKeys",
                "tblTransactions",
                "tblUsers"
            };
    }
}
