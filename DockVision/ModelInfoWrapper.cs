using SaigeVision.Net.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockVision
{
    public class ModelInfoWrapper
    {
        public string NetworkType { get; set; }
        public string DeveloperVersion { get; set; }
        public string ServerVersion { get; set; }
        public string ModuleVersion { get; set; }
        public double ResizeFactor { get; set; }
        public int CropSizeWidth { get; set; }
        public int CropSizeHeight { get; set; }
        public ClassInfo[] ClassInfos { get; set; }
        public bool[] ClassIsNG { get; set; }
    }
}
