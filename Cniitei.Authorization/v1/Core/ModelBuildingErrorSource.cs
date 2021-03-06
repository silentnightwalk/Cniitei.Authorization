﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cniitei.Authorization.v1.Core
{
    /// <summary>
    /// used to create mode building exception
    /// </summary>
    internal class ModelBuildingErrorSource
    {
        public string ElmType { get; set; }
        public int GlobalIndex { get; set; }
        public int? LocalIndex { get; set; }
        public string UniqueKeyIfExists { get; set; }
    }
}
