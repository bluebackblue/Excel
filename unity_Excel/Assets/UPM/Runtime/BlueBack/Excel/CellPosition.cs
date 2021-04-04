

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief セル位置。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** セル位置。
	*/
	public struct CellPosition
	{
		/** xy
		*/
		public readonly int x;
		public readonly int y;

		/** constructor
		*/
		public CellPosition(int a_x,int a_y)
		{
			this.x = a_x;
			this.y = a_y;
		}
	}
}

