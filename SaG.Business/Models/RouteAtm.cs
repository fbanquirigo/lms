using System;

namespace SaG.Business.Models
{   
    public class RouteAtm : BaseEntity
    {
        public int AtmEntity { get; set; }
        public int RouteEntity { get; set; }
        public Atm AtM { get; set; }
        public RouteDesc RouteDesc { get; set; }
        public Operator Operator { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as RouteAtm;
            if (t == null) return false;
            if (AtmEntity == t.AtmEntity
             && RouteEntity == t.RouteEntity)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ AtmEntity.GetHashCode();
            hash = (hash * 397) ^ RouteEntity.GetHashCode();

            return hash;
        }
        #endregion
    }
}

