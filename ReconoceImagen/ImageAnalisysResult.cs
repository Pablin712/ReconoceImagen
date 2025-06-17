using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconoceImagen
{
    internal class ImageAnalisysResult
    {
        public CaptionResult captionResult { get; set; }
        public ReadResult readResult { get; set; }

        public override string ToString()
        {
            var s = "";
            foreach(var block in readResult.blocks)
            {
                foreach (var line in block.lines)
                {
                    s += line.text + " ";
                }
            }
            return s;
        }
    }
}
