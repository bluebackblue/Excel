

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンフィグ。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** Config
	*/
	public class Config
	{
		/** ERRORPROC
		*/
		#if(DEF_BLUEBACK_EXCEL_ASSERT)
		public delegate void ErrorProcType(System.Exception a_exception,string a_message);
		public static ErrorProcType ERRORPROC = DebugTool.ErrorProc;
		#endif

		/** LOGPROC
		*/
		#if(DEF_BLUEBACK_EXCEL_LOG)
		public delegate void LogProcType(string a_message);
		public static LogProcType LOGPROC = DebugTool.LogProc;
		#endif

		/** COMMAND
		*/
		public const string COMMAND_END = "[end]";
		public const string COMMAND_ROOT = "[root]";
		public const string COMMAND_PARAM_TYPE = "[param_type]";
		public const string COMMAND_PARAM_NAME = "[param_name]";
		public const string COMMAND_ENABLELINE = "*";

		/** PARAMTYPE
		*/
		public const string PARAMTYPE_STRING = "string";
		public const string PARAMTYPE_INT = "int";
		public const string PARAMTYPE_FLOAT = "float";
	}
}

