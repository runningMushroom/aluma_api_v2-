using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Enum
{
    public enum ProcessorStatusEnum
    {
        WaitingForDependency,
        Started,
        DataCollected,
        FormCreated,
        SigningDocument,
        Complete
    }
}