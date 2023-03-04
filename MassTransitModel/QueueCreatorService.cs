using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitCommon
{
    public static class QueueCreatorService
    {
        public static string QueueGenerator(QueueEnum[] enums)
        {

            string queue = "";
            foreach (var item in enums)
            {
                if (item != enums[^1])
                {
                    queue += (item.DisplayName() + ".");
                }

                queue += item.DisplayName();

            }

            return queue;
        }
    }
}
