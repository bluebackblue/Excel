# BlueBack.Excel
Excel操作
* スプレッドシートからの読み込み
* バイナリからの読み込み
* JsonItemへのコンバート

## ライセンス
MIT License
* https://github.com/bluebackblue/Excel/blob/main/LICENSE

## 外部依存 / 使用ライセンス等
* https://github.com/bluebackblue/Excel/blob/main/unity_Excel/Assets/ThirdParty/ExcelDataReader/
* https://github.com/bluebackblue/JsonItem

### サンプルのみ
* https://github.com/bluebackblue/AssetLib

## 動作確認
Unity 2020.2.4f1

## URL
### 最新
* https://github.com/bluebackblue/Excel.git?path=unity_Excel/Assets/UPM#0.0.4
### 開発
* https://github.com/bluebackblue/Excel.git?path=unity_Excel/Assets/UPM

## Unityへの追加方法
* Unity起動
* メニュー選択：「Window->Package Manager」
* ボタン選択：「左上の＋ボタン」
* リスト選択：「Add package from git URL...」
* 上記のURLを追加「 https://github.com/～～/UPM#バージョン 」

### 注
Gitクライアントがインストールされている必要がある。
* https://docs.unity3d.com/ja/current/Manual/upm-git.html
* https://git-scm.com/

## サンプル

* ```[root]```の右はシート名。
* ```[param_type]```の右は型を列挙```string``` ```int``` ```float```が指定可能、```-```始まりはコメント扱い。
* ```[param_name]```の右は名前を列挙。
* ```*```のある行がコンバート対象。
* 終端には```[end]```が必要。
* 左上が'''[end]''のあるシートはスキップする。

![Sample01](/sample00.png)

```
{
	"sheetname" : [
		{
			"namae" : "satou",
			"nedan" : 10,
			"val" : 1.3
		},
		{
			"namae" : "sio",
			"nedan" : 20,
			"val" : 1.4
		},
		{
			"namae" : "shoyu",
			"nedan" : 30,
			"val" : 1.5
		}
	]
}
```