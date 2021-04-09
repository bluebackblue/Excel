

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief コンバート。
*/


/** BlueBack.Excel.ConvertToJson
*/
namespace BlueBack.Excel.ConvertToJson
{
	/** ConvertToJson
	*/
	public class ConvertToJson
	{
		/** Convert

			a_assets_path

		*/
		public static JsonItem.JsonItem Convert(Excel a_excel)
		{
			JsonItem.JsonItem t_excel_jsonitem = new JsonItem.JsonItem(new JsonItem.Value_AssociativeArray());

			int ii_max = a_excel.GetSheetCount();
			for(int ii=0;ii<ii_max;ii++){
				a_excel.SetActiveSheet(ii);
				System.Tuple<string,JsonItem.JsonItem> t_result = ConvertActiveSheet(a_excel);
				if(t_result.Item1 == null){
					//スキップ。
				}else if(t_excel_jsonitem.IsExistItem(t_result.Item1) == true){
					#if(DEF_BLUEBACK_EXCEL_ASSERT)
					DebugTool.Assert(false,"already_exist : " + t_result.Item1);
					#endif
				}else{
					t_excel_jsonitem.AddItem(t_result.Item1,t_result.Item2,false);
				}
			}

			return t_excel_jsonitem;
		}

		/** ConvertActiveSheet

			return tuple 1 : シート名。
			return tuple 2 : JsonItem。

		*/
		public static System.Tuple<string,JsonItem.JsonItem> ConvertActiveSheet(Excel a_excel,Param a_param = null)
		{
			Param t_param = a_param;
			if(t_param == null){
				t_param = new Param();
			}

			//左上が終端の場合はスキップする。
			{
				Result<CellPosition> t_pos_end = Find.FindCellTopPriorityFromActiveSheetRange(a_excel,0,0,0,0,Config.COMMAND_END);
				if(t_pos_end.success == true){
					return new System.Tuple<string,JsonItem.JsonItem>(null,null);
				}
			}

			//ルート検索。
			Result<CellPosition> t_pos_root = Find.FindCellLeftTopPriorityFromActiveSheetRange(a_excel,0,0,t_param.searchsize,Config.COMMAND_ROOT);
			if(t_pos_root.success == false){
				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,"no_root");
				#endif
				return new System.Tuple<string,JsonItem.JsonItem>(null,null);
			}

			//ルート名。
			Result<string> t_name_root = a_excel.TryGetCellStringFromActiveSheet(t_pos_root.value.x + 1,t_pos_root.value.y);

			//ルートより前に終端がある場合はスキップする。
			{
				Result<CellPosition> t_pos_end_skip = Find.FindCellTopPriorityFromActiveSheetRange(a_excel,0,0,t_pos_root.value.x,t_pos_root.value.y,Config.COMMAND_END);
				if(t_pos_end_skip.success == true){
					return new System.Tuple<string,JsonItem.JsonItem>(null,null);
				}
			}

			//Ｙ方向終端。
			Result<CellPosition> t_pos_end_y = Find.FindCellLeftPriorityFromActiveSheetRange(a_excel,t_pos_root.value.x,t_pos_root.value.y,t_pos_root.value.x,t_pos_root.value.y + t_param.searchsize,Config.COMMAND_END);
			if(t_pos_end_y.success == false){
				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,"no_end_y");
				#endif
				return new System.Tuple<string,JsonItem.JsonItem>(null,null);
			}

			//パラメータ。タイプ。
			Result<CellPosition> t_pos_param_type = Find.FindCellLeftPriorityFromActiveSheetRange(a_excel,t_pos_root.value.x,t_pos_root.value.y,t_pos_root.value.x,t_pos_end_y.value.y,Config.COMMAND_PARAM_TYPE);
			if(t_pos_param_type.success == false){
				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,"no_param_type");
				#endif
				return new System.Tuple<string,JsonItem.JsonItem>(null,null);
			}

			//パラメータ。名前。
			Result<CellPosition> t_pos_param_name = Find.FindCellLeftPriorityFromActiveSheetRange(a_excel,t_pos_root.value.x,t_pos_root.value.y,t_pos_root.value.x,t_pos_end_y.value.y,Config.COMMAND_PARAM_NAME);
			if(t_pos_param_name.success == false){
				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,"no_param_name");
				#endif
				return new System.Tuple<string,JsonItem.JsonItem>(null,null);
			}

			//Ｘ方向終端。
			Result<CellPosition> t_pos_end_x = Find.FindCellTopPriorityFromActiveSheetRange(a_excel,t_pos_root.value.x + 1,t_pos_root.value.y,t_pos_root.value.x + t_param.searchsize,t_pos_end_y.value.y,Config.COMMAND_END);
			if(t_pos_end_y.success == false){
				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,"no_end_x");
				#endif
				return new System.Tuple<string,JsonItem.JsonItem>(null,null);
			}

			//パラメータリスト。
			System.Collections.Generic.List<ParamListItem> t_paramlist = new System.Collections.Generic.List<ParamListItem>();
			{
				for(int xx = t_pos_param_type.value.x + 1;xx < t_pos_end_x.value.x;xx++){
					ParamType t_param_type;
					Result<string> t_cell_param_type = a_excel.TryGetCellStringFromActiveSheet(xx,t_pos_param_type.value.y);
					
					#pragma warning disable 0162
					switch(t_cell_param_type.value){
					case Config.PARAMTYPE_STRING:
						{
							t_param_type = ParamType.StringType;
						}break;
					case Config.PARAMTYPE_INT:
						{
							t_param_type = ParamType.IntType;
						}break;
					case Config.PARAMTYPE_FLOAT:
						{
							t_param_type = ParamType.FloatType;
						}break;
					default:
						{
							if(t_cell_param_type.value.Length == 0){
								//データのないセル。空白。
							}else if(t_cell_param_type.value[0] == '-'){
								//最初の１文字目がハイフンの場合は無視。
							}else{
								//不明なパラメータタイプ。

								#if(DEF_BLUEBACK_EXCEL_ASSERT)
								DebugTool.Assert(false,"unknown_param_type : " + t_cell_param_type.value + " :(" + xx + "," + t_pos_param_type.value.y  + ")");
								#endif
							}

							continue;
						}break;
					}
					#pragma warning restore

					Result<string> t_cell_param_name = a_excel.TryGetCellStringFromActiveSheet(xx,t_pos_param_name.value.y);
					if(t_cell_param_name.value.Length > 0){
						t_paramlist.Add(new ParamListItem(t_param_type,t_cell_param_name.value,xx));
					}else{
						//パラメーター名が空白。
						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false,"empty_param_name : " + t_cell_param_type.value + " :(" + xx + "," + t_pos_param_type.value.y  + ")");
						#endif

						continue;
					}
				}
			}

			{
				JsonItem.JsonItem t_sheet_json = new JsonItem.JsonItem(new JsonItem.Value_IndexArray());

				for(int yy=t_pos_root.value.y + 1;yy<t_pos_end_y.value.y;yy++){
					if(Find.CheckCellFromActiveSheet(a_excel,t_pos_root.value.x,yy,Config.COMMAND_ENABLELINE) == true){
						
						//ラインJSON作成。
						JsonItem.JsonItem t_line_jsonitem = new JsonItem.JsonItem(new JsonItem.Value_AssociativeArray());
						for(int ii=0;ii<t_paramlist.Count;ii++){
							switch(t_paramlist[ii].param_type){
							case ParamType.StringType:
								{
									Result<string> t_cell_value = a_excel.TryGetCellStringFromActiveSheet(t_paramlist[ii].pos_x,yy);
									t_line_jsonitem.AddItem(t_paramlist[ii].param_name,new JsonItem.JsonItem(new JsonItem.Value_StringData(t_cell_value.value)),false);
								}break;
							case ParamType.IntType:
								{
									Result<long> t_cell_value = a_excel.TryGetCellLongFromActiveSheet(t_paramlist[ii].pos_x,yy);
									t_line_jsonitem.AddItem(t_paramlist[ii].param_name,new JsonItem.JsonItem(new JsonItem.Value_Number<int>((int)t_cell_value.value)),false);
								}break;
							case ParamType.FloatType:
								{
									Result<double> t_cell_value = a_excel.TryGetCellDoubleFromActiveSheet(t_paramlist[ii].pos_x,yy);
									t_line_jsonitem.AddItem(t_paramlist[ii].param_name,new JsonItem.JsonItem(new JsonItem.Value_Number<float>((float)t_cell_value.value)),false);
								}break;
							default:
								{
									//未対応のタイプ。

									#if(DEF_BLUEBACK_EXCEL_ASSERT)
									DebugTool.Assert(false,"unknown_param_type : " + t_paramlist[ii].param_type.ToString() + " : " +  t_paramlist[ii].param_name);
									#endif
								}break;
							}
						}

						t_sheet_json.AddItem(t_line_jsonitem,false);
					}else{
						//無効ライン。
						continue;
					}
				}

				return new System.Tuple<string,JsonItem.JsonItem>(t_name_root.value,t_sheet_json);
			}
		}	
	}
}

