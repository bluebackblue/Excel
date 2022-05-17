

/** BlueBack.Excel.Samples.Convert.Editor
*/
#if(!DEF_BLUEBACK_EXCEL_SAMPLES_DISABLE)
namespace BlueBack.Excel.Samples.Convert.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** ローカル。
		*/
		[UnityEditor.MenuItem("Samples/Excel/Convert/FromLocal")]
		private static void MenuItem_FromLocal()
		{
			string t_path = BlueBack.AssetLib.Editor.FindFileWithAssetsPath.FindFirst("","","^excel\\.xlsx$");
			byte[] t_data = BlueBack.AssetLib.Editor.LoadBinaryWithAssetsPath.Load(t_path);

			if(t_data == null){
				UnityEngine.Debug.Log("data = null");
			}else{
				UnityEngine.Debug.Log("data = " + t_data.Length.ToString());

				BlueBack.Excel.Excel t_excel = new BlueBack.Excel.Excel(new BlueBack.Excel.EDR.Engine());
			
				t_excel.ReadOpen(t_data);
				BlueBack.JsonItem.JsonItem t_excel_jsonitem = BlueBack.Excel.ConvertToJson.ConvertToJson.Convert(t_excel,BlueBack.Excel.ConvertToJson.ConvertParam.CreateDefault());
				t_excel.Close();

				foreach(string t_sheetname in t_excel_jsonitem.GetAssociativeKeyList()){
					UnityEngine.Debug.Log("sheetname = " + t_sheetname);

					BlueBack.JsonItem.JsonItem t_sheet_jsonitem = t_excel_jsonitem.GetItem(t_sheetname);
					int t_line_max = t_sheet_jsonitem.GetListMax();
					UnityEngine.Debug.Log("line_max = " + t_line_max.ToString());

					for(int ii=0;ii<t_line_max;ii++){
						BlueBack.JsonItem.JsonItem t_line_jsonitem = t_sheet_jsonitem.GetItem(ii);
						UnityEngine.Debug.Log(t_line_jsonitem.ConvertToJsonString());
					}
				}
			}
		}

		/** ネットワーク。
		*/
		[UnityEditor.MenuItem("Samples/Excel/Convert/FromNetwork")]
		private static void MenuItem_FromNetwork()
		{
			byte[] t_data = BlueBack.AssetLib.Editor.LoadBinaryWithUrl.Load("https://docs.google.com/spreadsheets/d/1ZMGuCvnKSxBRYy8rYv9oh9KjcktXcte12i_5QSmYIPo/export?format=xlsx",null);

			if(t_data == null){
				UnityEngine.Debug.Log("data = null");
			}else{
				UnityEngine.Debug.Log("data = " + t_data.Length.ToString());

				BlueBack.Excel.Excel t_excel = new BlueBack.Excel.Excel(new BlueBack.Excel.EDR.Engine());
			
				t_excel.ReadOpen(t_data);
				BlueBack.JsonItem.JsonItem t_excel_jsonitem = BlueBack.Excel.ConvertToJson.ConvertToJson.Convert(t_excel,BlueBack.Excel.ConvertToJson.ConvertParam.CreateDefault());
				t_excel.Close();

				foreach(string t_sheetname in t_excel_jsonitem.GetAssociativeKeyList()){
					UnityEngine.Debug.Log("sheetname = " + t_sheetname);

					BlueBack.JsonItem.JsonItem t_sheet_jsonitem = t_excel_jsonitem.GetItem(t_sheetname);
					int t_line_max = t_sheet_jsonitem.GetListMax();
					UnityEngine.Debug.Log("line_max = " + t_line_max.ToString());

					for(int ii=0;ii<t_line_max;ii++){
						BlueBack.JsonItem.JsonItem t_line_jsonitem = t_sheet_jsonitem.GetItem(ii);
						UnityEngine.Debug.Log(t_line_jsonitem.ConvertToJsonString());
					}
				}
			}
		}
	}
	#endif
}
#endif

