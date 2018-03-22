using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;

namespace BtNodeEditor
{
    [NodeCanvasType("Bt Canvas")]
    public class BtCanvas : NodeCanvas
    {
        public override string canvasName
        {
            get
            {
                return "Bt";
            }
        }


    }
}
