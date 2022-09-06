using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum Status
    {
        //Verileri görüntülerken deleted olanları göstermezsin
        //Veri tabanının veri silinmesi gerçekleşmez veri passive olur
        Active=1,
        Modified,
        Deleted
    }
}
