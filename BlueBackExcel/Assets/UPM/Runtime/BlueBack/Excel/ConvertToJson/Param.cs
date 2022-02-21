

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief コンバート。
*/


/** BlueBack.Excel.ConvertToJson
*/
namespace BlueBack.Excel.ConvertToJson
{
	/** ConvertParam
	*/
	public struct ConvertParam
	{
		/** searc
		*/
		public int searchsize;

		/** CreateDefault
		*/
		public static ConvertParam CreateDefault()
		{
			return new ConvertParam(){
				searchsize = 1000,
			};
		}
	}
}

