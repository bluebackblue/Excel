

/** Samples.Excel.Convert.Editor
*/
namespace Samples.Excel.Convert.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** ローカル。
		*/
		[UnityEditor.MenuItem("サンプル/Excel/Convert/Local")]
		private static void MenuItem_Local()
		{
			string t_path = BlueBack.AssetLib.FindFile.FindFileFistFromAssetsPath("","","^excel\\.xlsx$");
			byte[] t_data = BlueBack.AssetLib.LoadBinary.LoadBinaryFromAssetsPath(t_path);

			if(t_data == null){
				UnityEngine.Debug.Log("data = null");
			}else{
				UnityEngine.Debug.Log("data = " + t_data.Length.ToString());

				BlueBack.Excel.Excel t_excel = new BlueBack.Excel.Excel(new BlueBack.Excel.EDR.Engine());
			
				t_excel.ReadOpen(t_data);
				BlueBack.JsonItem.JsonItem t_excel_jsonitem = BlueBack.Excel.ConvertToJson.ConvertToJson.Convert(t_excel);
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
		[UnityEditor.MenuItem("サンプル/Excel/Convert/Network")]
		private static void MenuItem_Network()
		{
			byte[] t_data = null;
			{
				UnityEngine.Networking.UnityWebRequest t_webrequest = UnityEngine.Networking.UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/1ZMGuCvnKSxBRYy8rYv9oh9KjcktXcte12i_5QSmYIPo/export?format=xlsx");
				UnityEngine.Networking.UnityWebRequestAsyncOperation t_async = t_webrequest.SendWebRequest();
				while(true){
					System.Threading.Thread.Sleep(1);

					if(t_webrequest.error != null){
						UnityEngine.Debug.Log("error : " + t_webrequest.error);
					}else{
						if(t_async.isDone == false){
							//処理中。
							UnityEngine.Debug.Log("do");
						}else{
							//完了。
							UnityEngine.Debug.Log("fix : " + t_webrequest.responseCode.ToString());
							t_data = t_webrequest.downloadHandler.data;
							break;
						}
					}
				}
			}

			if(t_data == null){
				UnityEngine.Debug.Log("data = null");
			}else{
				UnityEngine.Debug.Log("data = " + t_data.Length.ToString());

				BlueBack.Excel.Excel t_excel = new BlueBack.Excel.Excel(new BlueBack.Excel.EDR.Engine());
			
				t_excel.ReadOpen(t_data);
				BlueBack.JsonItem.JsonItem t_excel_jsonitem = BlueBack.Excel.ConvertToJson.ConvertToJson.Convert(t_excel);
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

