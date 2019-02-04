using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster.Math
{
    public class GenericMatrix
    {
        #region Public Fields
        /// <summary>
        /// 
        /// </summary>
        private int row;
        /// <summary>
        /// 
        /// </summary>
        private int column;
        /// <summary>
        /// 
        /// </summary>
        private float[,] matrix;
        #endregion Public Fields

        public int Row
        {
            get
            {
                return row;
            }
        }

        public int Column
        {
            get
            {
                return column;
            }
        }

        #region Constructor
        public GenericMatrix(int r, int c)
        {
            if (r <= 0 || c <= 0)
                return;

            row     = r;
            column  = c;
            matrix  = new float[r, c];
        }
        #endregion Constructor
        
    }
}
