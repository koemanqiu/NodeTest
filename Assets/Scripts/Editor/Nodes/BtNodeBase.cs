using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using System;

namespace BtNodeEditor
{

    [Node(true, "Bt/Bt Node Base", new Type[] { typeof(BtCanvas) })]
    public abstract class BtNodeBase : Node
    {
        public override bool AllowRecursion
        {
            get
            {
                return true;
            }
        }

        public abstract Type GetOjbectType { get; }

        public override Vector2 DefaultSize
        {
            get
            {
                return new Vector2(100, 50);
            }
        }


        //public abstract BtNodeBase Input(int inputValue);
        //public abstract bool IsBackAvailable();
        //public abstract bool IsNextAvailable();

        //public virtual BtNodeBase PassAhead(int inputValue)
        //{
        //    return this;
        //}

        //protected bool IsAvailable(ConnectionPort port)
        //{
        //    return port != null &&
        //        port.connections != null && port.connections.Count > 0 &&
        //        port.connections[0].body != null &&
        //        port.connections[0].body != default(Node);
        //}

        //protected BtNodeBase GetTargetNode(ConnectionPort port)
        //{
        //    if(IsAvailable(port))
        //    {
        //        return port.connections[0].body as BtNodeBase;
        //    }

        //    return null;
        //}
    }

    public class BtBackType : ConnectionKnobStyle
    {
        public override string Identifier
        {
            get
            {
                return "BtIn";
            }
        }

        public override Color Color
        {
            get
            {
                return Color.cyan;
            }
        }

    }

    public class BtForwardType : ConnectionKnobStyle
    {
        public override string Identifier
        {
            get
            {
                return "BtOut";
            }
        }

        public override Color Color
        {
            get
            {
                return Color.cyan;
            }
        }
    }

}
