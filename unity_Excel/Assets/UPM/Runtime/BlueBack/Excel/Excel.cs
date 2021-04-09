

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief エンジン。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** Excel
	*/
	public class Excel
	{
		/** engine
		*/
		private Engine_Base engine;

		/** constructor
		*/
		public Excel(Engine_Base a_engine)
		{
			this.engine = a_engine;
		}

		/** ReadOpen
		*/
		public void ReadOpen(byte[] a_data)
		{
			this.engine.ReadOpen(a_data);
		}

		/** Close
		*/
		public void Close()
		{
			this.engine.Close();
		}

		/** シート数。取得。
		*/
		public int GetSheetCount()
		{
			return this.engine.GetSheetCount();
		}

		/** アクティブシート。設定。
		*/
		public void SetActiveSheet(int a_sheet_index)
		{
			this.engine.SetActiveSheet(a_sheet_index);
		}

		/** 文字列。取得。
		*/
		public Result<string> TryGetCellStringFromActiveSheet(int a_x,int a_y)
		{
			this.engine.SetActiveCell(a_x,a_y);
			return this.engine.TryGetCellString();
		}

		/** 少数。取得。
		*/
		public Result<double> TryGetCellDoubleFromActiveSheet(int a_x,int a_y)
		{
			this.engine.SetActiveCell(a_x,a_y);
			return this.engine.TryGetCellDouble();
		}

		/** 整数。取得。
		*/
		public Result<long> TryGetCellLongFromActiveSheet(int a_x,int a_y)
		{
			this.engine.SetActiveCell(a_x,a_y);
			return this.engine.TryGetCellLong();
		}
	}
}

