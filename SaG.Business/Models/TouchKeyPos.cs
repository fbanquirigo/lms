namespace SaG.Business.Models
{

    public class TouchKeyPos : BaseEntity
    {
        public string TouchKeyId { get; set; }
        public short PositionNo { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public TouchKey TouchKey { get; set; }
        public Cmd CmdId0 { get; set; }
        public Cmd CmdId1 { get; set; }
        public Cmd CmdId2 { get; set; }
        public Cmd CmdId3 { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as TouchKeyPos;
            if (t == null) return false;
            if (TouchKeyId == t.TouchKeyId
             && PositionNo == t.PositionNo)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ TouchKeyId.GetHashCode();
            hash = (hash * 397) ^ PositionNo.GetHashCode();

            return hash;
        }
        #endregion
    }
}
