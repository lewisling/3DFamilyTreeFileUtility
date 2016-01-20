using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DFamilyTreeFileUtility
{
    /// <summary> Displays a wait cursor while an instance is in scope. </summary>
    public class WaitCursor : IDisposable
    {
        public Cursor PriorCursor { get; private set; }

        public WaitCursor()
        {
            PriorCursor = Cursor.Current;
            Cursor.Current = Cursors.AppStarting;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (PriorCursor != null)
                {
                    Cursor.Current = PriorCursor;
                    PriorCursor = null;
                }
            }
        }
    }
}
