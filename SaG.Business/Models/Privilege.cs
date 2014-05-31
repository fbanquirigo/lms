namespace SaG.Business.Models
{

    public class Privilege : BaseEntity
    {
        public int DispEntity { get; set; }
        public int CmdId { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public Cmd Cmd { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as Privilege;
            if (t == null) return false;
            if (DispEntity == t.DispEntity
             && CmdId == t.CmdId)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ DispEntity.GetHashCode();
            hash = (hash * 397) ^ CmdId.GetHashCode();

            return hash;
        }
        #endregion
    }
}
