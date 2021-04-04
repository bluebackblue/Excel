

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンバート。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** Param
	*/
	public class Param
	{
		/** command_end
		*/
		public string command_end;
		public string command_root;
		public string command_param_type;
		public string command_param_name;

		/** searc
		*/
		public int searchsize;

		/** constructor
		*/
		public Param()
		{
			//command
			this.command_end = "[end]";
			this.command_root = "[root]";
			this.command_param_type = "[param_type]";
			this.command_param_name = "[param_name]";

			//searchsize
			this.searchsize = 1000;
		}
	}
}

