using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster.Math
{
    public class GenericMatrix<T>
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
        private T[] matrix;
        #endregion Public Fields

        #region Public Instance Properties
        /// <summary>
        /// 
        /// </summary>
        public int Row
        {
            get { return row; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Column
        {
            get { return column; }
        }
        #endregion Public Instance Properties

        #region Constructor
        public GenericMatrix(int r, int c)
        {
            if (r <= 0 || c <= 0)
                return;

            row     = r;
            column  = c;
            matrix  = new T[r * c];
        }
   
        #endregion Constructor
        
    }
}
