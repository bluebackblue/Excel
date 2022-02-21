

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 検索。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** Find
	*/
	public static class Find
	{
		/** CheckCellFromActiveSheet
		*/
		public static bool CheckCellFromActiveSheet(Excel a_excel,int a_x1,int a_y1,string a_text)
		{
			Result<string> t_cell_string = a_excel.TryGetCellStringFromActiveSheet(a_x1,a_y1);
			if(t_cell_string.value == a_text){
				return true;
			}else{
				return false;
			}
		}

		/** セル検索。上優先。
		*/
		public static Result<CellPosition> FindCellTopPriorityFromActiveSheetRange(Excel a_excel,int a_x1,int a_y1,int a_x2,int a_y2,string a_text)
		{
			for(int yy=a_y1;yy<=a_y2;yy++){
				for(int xx=a_x1;xx<=a_x2;xx++){
					if(CheckCellFromActiveSheet(a_excel,xx,yy,a_text) == true){
						//一致。

						return new Result<CellPosition>(){
							success = true,
							value = new CellPosition(xx,yy),
						};
					}else{
						//不一致。
					}
				}
			}

			//未発見。
			return new Result<CellPosition>(){
				success = false,
				value = new CellPosition(0,0),
			};
		}

		/** セル検索。左優先。
		*/
		public static Result<CellPosition> FindCellLeftPriorityFromActiveSheetRange(Excel a_excel,int a_x1,int a_y1,int a_x2,int a_y2,string a_text)
		{
			for(int xx=a_x1;xx<=a_x2;xx++){
				for(int yy=a_y1;yy<=a_y2;yy++){
					if(CheckCellFromActiveSheet(a_excel,xx,yy,a_text) == true){
						//一致。

						return new Result<CellPosition>(){
							success = true,
							value = new CellPosition(xx,yy),
						};
					}else{
						//不一致。
					}
				}
			}

			//未発見。
			return new Result<CellPosition>(){
				success = false,
				value = new CellPosition(0,0),
			};
		}

		/** セル検索。左上優先。
		*/
		public static Result<CellPosition> FindCellLeftTopPriorityFromActiveSheetRange(Excel a_excel,int a_x,int a_y,int a_size,string a_text)
		{
			for(int t_size=1;t_size<a_size;t_size++){
				
				//下。
				{
					int yy = t_size - 1;
					for(int xx=0;xx<t_size;xx++){
						if(CheckCellFromActiveSheet(a_excel,xx,yy,a_text) == true){
							//一致。

							return new Result<CellPosition>(){
								success = true,
								value = new CellPosition(xx,yy),
							};
						}else{
							//不一致。
						}
					}
				}

				//右。
				{
					int xx = t_size - 1;
					for(int yy=0;yy<t_size-1;yy++){
						if(CheckCellFromActiveSheet(a_excel,xx,yy,a_text) == true){
							//一致。

							return new Result<CellPosition>(){
								success = true,
								value = new CellPosition(xx,yy),
							};
						}else{
							//不一致。
						}
					}
				}
			}

			//未発見。
			return new Result<CellPosition>(){
				success = false,
				value = new CellPosition(0,0),
			};
		}
	}
}

