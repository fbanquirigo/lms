using System;

namespace SaG.Business.Models
{

    public class TouchKeyParm : BaseEntity
    {
        public int DispEntity { get; set; }
        public string TouchKeyId { get; set; }
        public int CmdId { get; set; }
        public string BankModeStatus { get; set; }
        public string AuditStatus { get; set; }
        public string TampResetStatus { get; set; }
        public DateTime? TimeStartBankAccess { get; set; }
        public DateTime? TimeEndBankAccess { get; set; }
        public bool EraseCodes { get; set; }
        public string NewPcCode { get; set; }
        public string NewOcCode { get; set; }
        public DateTime? TimeStartSetClock { get; set; }
        public short? SequenceNum { get; set; }
        public int? AddRevDispEntity { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as TouchKeyParm;
            if (t == null) return false;
            if (DispEntity == t.DispEntity
             && TouchKeyId == t.TouchKeyId
             && CmdId == t.CmdId)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ DispEntity.GetHashCode();
            hash = (hash * 397) ^ TouchKeyId.GetHashCode();
            hash = (hash * 397) ^ CmdId.GetHashCode();

            return hash;
        }
        #endregion
    }
}
