using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Entities
{
    public class Building
    {
        public virtual int Id { get; set; }
        public virtual string Type { get; set; }
        public virtual bool HasWindows { get; set; }
        public virtual bool IsIndustrial { get; set; }
        public virtual IList<Place> Places { get; set; }

        public virtual string InfoWindows()
        {
            string windowsInfo;


            if (HasWindows)
                windowsInfo = "Tak";
            else
                windowsInfo = "Nie";
            return windowsInfo;
        }
        public virtual string InfoIndustrial()
        {
            string industrialInfo;

            if (IsIndustrial)
                industrialInfo = "Tak";
            else
                industrialInfo = "Nie";

            return industrialInfo;
        }

    }
}
