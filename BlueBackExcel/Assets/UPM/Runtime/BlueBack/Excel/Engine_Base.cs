

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief エンジン。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** Engine_Base
	*/
	public interface Engine_Base
	{
		/** [BlueBack.Excel.Engine_Base]開く。
		*/
		public bool ReadOpen(byte[] a_data);

		/** [BlueBack.Excel.Engine_Base]閉じる。
		*/
		public void Close();

		/** [BlueBack.Excel.Engine_Base]シート数。取得。
		*/
		public int GetSheetCount();

		/** [BlueBack.Excel.Engine_Base]アクティブシート。設定。
		*/
		public void SetActiveSheet(int a_sheet_index);

		/** [BlueBack.Excel.Engine_Base]アクティブセル。設定。
		*/
		public void SetActiveCell(int a_x,int a_y);

		/** [BlueBack.Excel.Engine_Base]文字列。取得。
		*/
		public Result<string> TryGetCellString();

		/** [BlueBack.Excel.Engine_Base]少数。取得。
		*/
		public Result<double> TryGetCellDouble();

		/** [BlueBack.Excel.Engine_Base]整数。取得。
		*/
		public Result<long> TryGetCellLong();
	}
}

